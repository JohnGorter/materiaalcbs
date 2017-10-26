using System;
using System.Collections;
using MyProgram.BaseGame;

namespace MyProgram.ConcreteGames
{
    public class HangmanGame : Game
    {
        IWoordenlijst woordenlijst;
        public int aantalpogingen;
        public string woord, geradenwoord;

        public HangmanGame(IWoordenlijst wlijst) { woordenlijst = wlijst; }
        public HangmanGame() : this(new RandomWoordenlijst()){}

        public override void nextTurn(String speler)
        {
            string letter = ScoreBoard.ask($"{speler}: Geef een letter:");
            string tussenwaarde = "";
            for (int i = 0; i < woord.Length; i++)
                tussenwaarde += (woord[i].ToString().ToUpper().Equals(letter.ToUpper())) ? letter : geradenwoord[i].ToString();
            if (woord.IndexOf(letter, StringComparison.InvariantCulture) < 0)
                aantalpogingen = aantalpogingen - 1;
            geradenwoord = tussenwaarde;
            ScoreBoard.show("Woord: " + geradenwoord + " pogingen:" + aantalpogingen);
        }

        public override void exit() { }

        public override void init(){
            woord = woordenlijst.getWoord(); 
            geradenwoord = woordenlijst.getMask(woord, ".");
            aantalpogingen = 10;
            ScoreBoard.show(geradenwoord);
        }

        public override bool gameOver()
        {
            if ((aantalpogingen != 0 && !woord.ToLower().Equals(geradenwoord.ToLower()))) return false;
            ScoreBoard.show((aantalpogingen == 0) ? "Jammer! Het woord was " + woord : "Goed gedaan! Het woord is geraden");
            woordenlijst.removeWoord(woord);
            if (woordenlijst.getCount() == 0) return true;
            string answer = ScoreBoard.ask("Wil u het volgende woord spelen? <y/n>");
            if (answer.Equals("y")) init();
            return answer.Equals("n");
        }
    }
}
