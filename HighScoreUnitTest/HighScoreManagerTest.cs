using HuntTheWumpus.HighScore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HighScoreUnitTest
{
    [TestClass]
    public class HighScoreManagerTest
    {
        [TestMethod]
        public void AddCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();

            DateTime dt = DateTime.Now;

            highscoreManager.Add("testNmae", 100, "", dt);

            HighScore highscore = new HighScore("testNmae", 100, "", dt);

            Assert.AreEqual(highscore, highscoreManager.GetHighScore("testNmae"));
        }

        [TestMethod]
        public void AddNotCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();
           // Assert.Fail((highscoreManager.Add("", 1, null, DateTime.Now));
        }
        [TestMethod]
        public void SortCorrect()
        {

        }
        [TestMethod]
        public void SortNotCorrect()
        {

        }
    }
}
