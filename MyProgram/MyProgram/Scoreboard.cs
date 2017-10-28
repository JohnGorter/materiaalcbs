using System;
namespace MyProgram
{
    public class Scoreboard
    {
        public void show(string arg)
        {
            Console.WriteLine(arg);
        }

        public string ask(string line)
        {
            Console.WriteLine(line);
            return Console.ReadLine();
        }
    }
}
