using System;

namespace MyProgram
{
    public class Program
    {
        public static string woord = "hallowereld";
        public static int aantalpogingen = 10;

        public static void show(string arg){
            Console.WriteLine(arg);
        }

        public static String maskWord(string woord, string character)
        {
            // onthoud tussenwaarde
            string retval = "";
            // voor iedere letter in het woord
            for (int i = 0; i < woord.Length; i++)
            {
                // voeg een puntje toe aan tussenwaarde
                retval += ".";
            }
            // retourneer tussenwaarde
            return retval;
        }

        public static string askLetter(){
            Console.WriteLine("Geef een letter:");
            return Console.ReadLine();
        }

        public static bool gameover(int aantalpogingen, string woord, string geradenwoord){
            // return aantal pogingen == 0 of woord is gelijk aan geradenwoord
            return (aantalpogingen == 0 || woord.Equals(geradenwoord));
        }


        public static string processLetter(string geradenwoord, string letter) {
            // zet gevonden op onwaar
			bool found = false;
            // zet tussenwaarde op lege waarde
            string tussenwaarde = "";
            // loop door de letters van het geheime woord
            for (int i = 0; i < woord.Length; i++)
            {
                // als de letter op die plek gelijk is aan de meegegeven letter
                if (woord[i].ToString().ToUpper().Equals(letter.ToUpper()))
                {
                    // tussenwaarde += woord[positie]
                    tussenwaarde += letter;
                    // gevonden is waar
                    found = true;
                }
                else
                {
                    tussenwaarde += geradenwoord[i].ToString();
                }

            }
            // als gevonden onwaar is
            if (!found)
                aantalpogingen = aantalpogingen - 1;
            
            return tussenwaarde;
        }

        public static void Main(string[] args)
        {
            // schrijf header
            show("Welcome to hangman!");

            woord = "hallowereld";
            string geradenwoord = maskWord(woord, ".");

            // toon woord in puntjes
            show(geradenwoord); 

            // zolang niet gameover()
            while (!gameover(aantalpogingen, woord, geradenwoord))
            {
                // vraagletter // verwerkletter
                geradenwoord = processLetter(geradenwoord, askLetter());
                // toon resultaat aan gebruiker
                show("Woord: " + geradenwoord + " pogingen:" + aantalpogingen);

            }

            // als geraden
            if (woord.Equals(geradenwoord))
                // toon hoera gewonnen
                show("Hooray, u have won!");
            // anders
            else
                // toon jammer, het woord was ..
                show("Too bad, the word was " + woord);
            

        }
    }
}
