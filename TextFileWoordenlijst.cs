using System;
using System.Collections;

namespace MyProgram
{
    public class TextFileWoordenlijst : Woordenlijst
    {
        ArrayList woorden = new ArrayList();
     

        public TextFileWoordenlijst()
        {
            Console.WriteLine("I am a tekstbestand woordenlijst generator");
            var regels = System.IO.File.ReadLines("./woorden.txt");
            foreach(var line in regels){
                woorden.Add(line.Trim());
            }
        }

        public override int getCount()
        {
            return woorden.Count;
        }

        public override string getWoord()
        {
            return (string)woorden[0];
        }

        public override void removeWoord(string woord)
        {
            woorden.Remove(woord);
        }
    }
}
