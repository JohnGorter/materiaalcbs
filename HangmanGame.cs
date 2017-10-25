using System;
namespace MyProgram
{
    public class HangmanGame
    {
        string woord = "hallowereld";
        int aantalpogingen = 10;
        InOut inout = new InOut(); 

        String maskWord(string woord, string character)
        {
            // onthoud tussenwaarde
            string retval = "";
            // voor iedere letter in het woord
            foreach(var l in woord) retval += character;
            // retourneer tussenwaarde
            return retval;
        }



        bool gameover(int aantalpogingen, string woord, string geradenwoord)
        {
            // return aantal pogingen == 0 of woord is gelijk aan geradenwoord
            return (aantalpogingen == 0 || woord.Equals(geradenwoord));
        }


        string processLetter(string geradenwoord, string letter)
        {
            // zet tussenwaarde op lege waarde
            string tussenwaarde = "";
            // loop door de letters van het geheime woord
            for (int i = 0; i < woord.Length; i++)
                // als de letter op die plek gelijk is aan de meegegeven letter
                tussenwaarde += (woord[i].ToString().ToUpper().Equals(letter.ToUpper())) ? letter : geradenwoord[i].ToString();

            // als gevonden onwaar is
            if (woord.IndexOf(letter, StringComparison.InvariantCulture) < 0)
                aantalpogingen = aantalpogingen - 1;

            return tussenwaarde;
        }

        public void start(){

            // schrijf header
            inout.show("Welcome to hangman!");

            woord = "hallowereld";
            string geradenwoord = maskWord(woord, ".");

            // toon woord in puntjes
            inout.show(geradenwoord);

            // zolang niet gameover()
            do {
                // vraagletter // verwerkletter
                geradenwoord = processLetter(geradenwoord, inout.askLetter());
                // toon resultaat aan gebruiker
                inout.show("Woord: " + geradenwoord + " pogingen:" + aantalpogingen);
            }
            while (!gameover(aantalpogingen, woord, geradenwoord)) ;

            // als geraden
            if (woord.Equals(geradenwoord))
                // toon hoera gewonnen
                inout.show("Hooray, u have won!");
            // anders
            else
                // toon jammer, het woord was ..
                inout.show("Too bad, the word was " + woord);


        }
    }
}
