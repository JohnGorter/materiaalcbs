using System;
using System.Collections;

namespace MyProgram.BaseGame
{
    public abstract class Game
    {
        protected Scoreboard ScoreBoard = new Scoreboard();
        protected ArrayList Players = new ArrayList();
        protected int CurrentPlayer; 

        public void start()
        {
            ScoreBoard.show("Hello!");
            this.getPlayers();
            this.init();
            do
            {
                this.nextTurn((string)Players[CurrentPlayer]);
                CurrentPlayer = (++CurrentPlayer) % Players.Count;
            }
            while (!gameOver());

            this.exit();
            ScoreBoard.show("Goodbye!");
        }

        protected void getPlayers()
        {
            int players = int.Parse(ScoreBoard.ask("How many players are playing?"));
            for (int i = 0; i < players; i++)
                Players.Add(ScoreBoard.ask($"Name of player {i+1}:"));
            CurrentPlayer = 0;
        }

        #region abstract members
        public abstract void init();
        public abstract void nextTurn(String speler);
        public abstract bool gameOver();
        public abstract void exit();
        #endregion 

    }
}
