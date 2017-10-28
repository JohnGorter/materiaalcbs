using System;
namespace MyProgram
{
    public abstract class Woordenlijst : IWoordenlijst
    {
        public abstract int getCount();

        public string getMask(string woord, string character)
        {
            string retval = "";
            foreach(var l in woord) retval += character;
            return retval;
        }

        public abstract string getWoord();

        public abstract void removeWoord(string woord);
    }
}
