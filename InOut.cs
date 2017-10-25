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

        public string askLetter(string line)
        {
            Console.WriteLine(line);
            return Console.ReadLine();
        }

    }
}
