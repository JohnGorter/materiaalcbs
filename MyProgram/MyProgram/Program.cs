using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyProgram.BaseGame;
using MyProgram.ConcreteGames;

namespace MyProgram
{
  

    public class Program
    {
        
        public static void Main(string[] args)
        {
            //Game g = new HangmanGame(new TextFileWoordenlijst());
            //Game g = new GetalOnderTienGame();
            Game g = new BoterKaasEnEieren();
            g.GameStarted += (s, e) => {
                Console.WriteLine("BoterkaasenEieren is gestart" + e.data);
            };

            g.GameEnded += () => {
                Console.WriteLine("BoterkaasenEieren is klaar");
            };
            g.start();
        }
    }
}
