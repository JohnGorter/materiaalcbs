using System;
using System.Collections;

namespace MyProgram
{
    public class RandomWoordenlijst: Woordenlijst
    {
        ArrayList woorden = new ArrayList() { "hello", "woord" };

        public RandomWoordenlijst()
        {
            Console.WriteLine("I am a random woordenlijst generator");
        }

        public override int getCount()
        {
            return woorden.Count;
        }

        public override string getWoord()
        {
            return (string)woorden[new Random().Next(0, woorden.Count)];
        }

        public override void removeWoord(string woord)
        {
            woorden.Remove(woord);
        }
    }
}
