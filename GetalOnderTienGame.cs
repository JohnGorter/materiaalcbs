using System;
using MyProgram.BaseGame;

namespace MyProgram.ConcreteGames
{
    public class GetalOnderTienGame : Game
    {
        int geheimgetal;
        int getal;
        bool bContinue = true;
        int pogingen = 0;

        public override void init()
        {
            geheimgetal = new Random().Next(0, 11);
            ScoreBoard.show("Welkom bij getal onder de tien. Ik heb een getal, raad maar:");
        }

        public override void exit() {
            if (getal == geheimgetal)
            {
                ScoreBoard.show($"Goed gedaan in {pogingen} pogingen, het getal was inderdaad {geheimgetal} !!");
            } else {
                ScoreBoard.show($"Jammer, het getal was {geheimgetal}. U heeft het {pogingen} keer geprobeerd.");
            }
        }

        public override void nextTurn(String speler)
        {
            getal = Int32.Parse(ScoreBoard.ask($"{speler}: Geef een getal onder de tien."));
            pogingen++;
            if (getal != geheimgetal)
            {
                string answer = ScoreBoard.ask("Nee, dit is niet het getal. Wilt u nog een keer raden? <y/n>");
                if (answer.Equals("n")) bContinue = false;
            }
        }

        public override bool gameOver()
        {
            return getal == geheimgetal || !bContinue;
        }
    }
}
