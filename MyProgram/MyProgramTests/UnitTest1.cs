using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProgram;
using MyProgram.ConcreteGames;

namespace MyProgramTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HangManWordShouldBeWorld()
        {
            // ARRANGE
            HangmanGame hangman = new HangmanGame(new EenWoordWoordenlijst());
            // ACT
            hangman.init();

            // ASSERT
            Assert.AreEqual(hangman.woord, "world");


        }
        [TestMethod]
        public void WoordenlijstContainsOneWord()
        {
            // ARRANGE
            IWoordenlijst lijst = new EenWoordWoordenlijst();
            // ACT
            int count = lijst.getCount();

            // ASSERT
            Assert.AreEqual(count, 1);

        }



        [TestMethod]
        public void HangManAttemptsShouldbe10AfterInit()
        {
            // ARRANGE
            HangmanGame hangman = new HangmanGame(new EenWoordWoordenlijst());
            // ACT
            hangman.init();

       

            // ASSERT
            Assert.AreEqual(hangman.aantalpogingen, 10);

        }


    }

   
}
