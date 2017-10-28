using System;
using System.Collections;

namespace MyProgram
{
    public class EenWoordWoordenlijst : Woordenlijst
    {
        int woorden = 1;


        public EenWoordWoordenlijst()
        {
            Console.WriteLine("I am a eenwoord woordenlijst generator");
        }

        public override int getCount()
        {
            return woorden;
        }

        public override string getWoord()
        {
            return "world";
        }

        public override void removeWoord(string woord)
        {
            woorden--;
        }
    }
}
