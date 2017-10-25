using System;
using System.Collections;

namespace MyProgram
{
    public class HangmanGame
    {
        //ArrayList woorden = new ArrayList() { "hello", "woord" };
        IWoordenlijst woordenlijst;
        int aantalpogingen;
        string woord;
        string geradenwoord;
        InOut inout = new InOut();

        //public string GetRandomWord(){
        //    return (string)woorden[new Random().Next(0, woorden.Count)];
        //}

        public void init(){
            woord = woordenlijst.getWoord(); 
            geradenwoord = woordenlijst.getMask(woord, ".");
            aantalpogingen = 10;
            inout.show(geradenwoord);
        }

        //public string maskWord(string character)
        //{
        //    string retval = "";
        //    foreach(var l in woord) retval += character;
        //    return retval;
        //}

        bool roundover()
        {
            // return aantal pogingen == 0 of woord is gelijk aan geradenwoord
            if ((aantalpogingen != 0 && !woord.ToLower().Equals(geradenwoord.ToLower()))) return false;

            inout.show((aantalpogingen == 0) ? "Jammer! Het woord was " + woord : "Goed gedaan! Het woord is geraden");
            woordenlijst.removeWoord(woord);
            if (woordenlijst.getCount() == 0) return true;

            inout.show("Wil u het volgende woord spelen? <y/n>");
            string answer = inout.askLetter("");
            if (answer.Equals("y")) init();
            return answer.Equals("n");
           
        }

        string processLetter(string letter)
        {
            // zet tussenwaarde op lege waarde
            string tussenwaarde = "";
            // loop door de letters van het geheime woord
            for (int i = 0; i < woord.Length; i++)
                // als de letter op die plek gelijk is aan de meegegeven letter
                tussenwaarde += (woord[i].ToString().ToUpper().Equals(letter.ToUpper())) ? letter : geradenwoord[i].ToString();
            // als gevonden onwaar is
            if (woord.IndexOf(letter, StringComparison.InvariantCulture) < 0)
                aantalpogingen = aantalpogingen - 1;
            return tussenwaarde;
        }

        public void start(){
            // schrijf header
            inout.show("Welcome to hangman!");
            init();
            // zolang niet gameover()
            do {
                // vraagletter // verwerkletter
                geradenwoord = processLetter(inout.askLetter("Geef een letter:"));
                // toon resultaat aan gebruiker
                inout.show("Woord: " + geradenwoord + " pogingen:" + aantalpogingen);
            }
            while (!roundover()) ;
            // afsluiten, de melding is al geweest in de gameover routine
            inout.show("Goodbye!");
        }
    }
}
