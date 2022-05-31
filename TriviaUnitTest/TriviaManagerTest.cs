using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using HuntTheWumpus.Trivia;

namespace TriviaUnitTest
{
    [TestClass]
    public class TriviaManagerTest
    {
        [TestMethod]
        public void QuestionsCorrect()
        {
            TriviaManager triviaManager = new TriviaManager();

            triviaManager.ReadFile();
            Assert.AreEqual(triviaManager.GetRandomQuestion(3).Count, 3);
        }
    }
}
