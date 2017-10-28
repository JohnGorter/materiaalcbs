using System;
using MyProgram.BaseGame;

namespace MyProgram.ConcreteGames
{
    public class BoterKaasEnEieren : Game
    {
        
        protected enum Family { None, Round, Cross };
        Family[] bord = new Family[9];
        Family current = Family.Round;

        public override void init()
        {
            OnGameStarted(new GameStartedEventArgs("nog meer tekst"));
            for (int i = 0; i < bord.Length; i++)
                bord[i] = Family.None;
        }

        public override void exit()
        {
            var winner = GetWinner();
            if (winner != Family.None)
                ScoreBoard.show($"{formatFamily(winner)} heeft gewonnen!");
            else
                ScoreBoard.show("Het was een gelijk spel!");
                
        }

        public override bool gameOver()
        {
            if (GetWinner() != Family.None) return true;
            return IsBoardFull();
        }

        public override void nextTurn(string speler)
        {
            int place = int.Parse(ScoreBoard.ask($"{speler}: where would you like to place: " + (current == Family.Round ? "o" : "x") + "?"));
            bord[place] = current;
            for (int i = 0; i < 3; i++)
            {
                ScoreBoard.show(formatFamily(bord[i * 3]) + "|" 
                                + formatFamily(bord[(i * 3) + 1]) + "|" 
                                + formatFamily(bord[(i * 3) + 2]));
                if (i < 2) ScoreBoard.show("-----");
            }
            current = current == Family.Round ? Family.Cross : Family.Round;
        }

        protected Family GetWinner()
        {
            Family winner = Family.None;
            // check to see a winning combo
            if (bord[0] == bord[1] && bord[1] == bord[2] && bord[0] != Family.None) winner = bord[0];
            if (bord[3] == bord[4] && bord[4] == bord[5] && bord[3] != Family.None) winner = bord[3];
            if (bord[6] == bord[7] && bord[7] == bord[8] && bord[6] != Family.None) winner = bord[6];
            if (bord[0] == bord[3] && bord[3] == bord[6] && bord[0] != Family.None) winner = bord[0];
            if (bord[1] == bord[4] && bord[4] == bord[7] && bord[1] != Family.None) winner = bord[1];
            if (bord[2] == bord[5] && bord[5] == bord[8] && bord[2] != Family.None) winner = bord[2];
            if (bord[0] == bord[4] && bord[4] == bord[8] && bord[0] != Family.None) winner = bord[0];
            if (bord[2] == bord[4] && bord[4] == bord[6] && bord[2] != Family.None) winner = bord[2];
            return winner;
        }

        protected bool IsBoardFull(){
            // check to see if the board is full
            Boolean bFull = true;
            for (int i = 0; i < 9; i++)
            {
                if (bord[i] == Family.None)
                {
                    bFull = false;
                    break;
                }
            }
            return bFull;
        }

        protected string formatFamily(Family f){
            switch (f){
                case Family.None: return " ";
                case Family.Round: return "o";
                case Family.Cross: return "x";
            }
            return "";
        }
    }
}
