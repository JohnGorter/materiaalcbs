using System;
namespace MyProgram
{
    public class InOut
    {
        public InOut()
        {
        }

        public void show(string arg)
        {
            Console.WriteLine(arg);
        }

        public string askLetter()
        {
            Console.WriteLine("Geef een letter:");
            return Console.ReadLine();
        }

    }
}
