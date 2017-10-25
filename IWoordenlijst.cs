using System;
namespace MyProgram
{
    public interface IWoordenlijst
    {
        int getCount();
        string getWoord();
        string getMask(string woord, string character);
        void removeWoord(string woord);
    }
}
