using System;
using System.Collections;

namespace MyProgram
{
    public class HangmanGame
    {
        IWoordenlijst woordenlijst;
        public int aantalpogingen;
        public string woord, geradenwoord;
        InOut inout = new InOut();

        public HangmanGame(IWoordenlijst wlijst)
        {
            woordenlijst = wlijst;
        }

        public HangmanGame() : this(new RandomWoordenlijst()){}
        

        public void init(){
            woord = woordenlijst.getWoord(); 
            geradenwoord = woordenlijst.getMask(woord, ".");
            aantalpogingen = 10;
            inout.show(geradenwoord);
        }

        public bool roundover()
        {
            if ((aantalpogingen != 0 && !woord.ToLower().Equals(geradenwoord.ToLower()))) return false;
            inout.show((aantalpogingen == 0) ? "Jammer! Het woord was " + woord : "Goed gedaan! Het woord is geraden");
            woordenlijst.removeWoord(woord);
            if (woordenlijst.getCount() == 0) return true;
            inout.show("Wil u het volgende woord spelen? <y/n>");
            string answer = inout.askLetter("");
            if (answer.Equals("y")) init();
            return answer.Equals("n");
        }

        public string processLetter(string letter)
        {
            string tussenwaarde = "";
            for (int i = 0; i < woord.Length; i++)
                tussenwaarde += (woord[i].ToString().ToUpper().Equals(letter.ToUpper())) ? letter : geradenwoord[i].ToString();
            if (woord.IndexOf(letter, StringComparison.InvariantCulture) < 0)
                aantalpogingen = aantalpogingen - 1;
            return tussenwaarde;
        }

        public void start(){
            inout.show("Welcome to hangman!");
            init();
            do {
                geradenwoord = processLetter(inout.askLetter("Geef een letter:"));
                inout.show("Woord: " + geradenwoord + " pogingen:" + aantalpogingen);
            }
            while (!roundover()) ;
            inout.show("Goodbye!");
        }
    }
}
