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

            Assert.IsNotNull(highscoreManager.Add("testNmae", 100, -1, DateTime.Now));
        }

        [TestMethod]
        public void AddNotCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();
            Assert.IsNotNull(highscoreManager.Add("", null, null, DateTime.Now));
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
