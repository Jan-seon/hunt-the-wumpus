using Microsoft.VisualStudio.TestTools.UnitTesting;
using HuntTheWumpus.Trivia;
using System;

namespace TriviaUnitTest
{
    [TestClass]
    public class TriviaManagerTest
    {
        [TestMethod]
        public void QuestionQuantityCorrect()
        {
            TriviaManager triviaManager = new TriviaManager();

            triviaManager.ReadFile();
            Assert.AreEqual(triviaManager.GetRandomQuestion(3).Count, 3);
        }

        [TestMethod]
        public void QuestionQuantityIncorrect()
        {
            TriviaManager triviaManager = new TriviaManager();

            triviaManager.ReadFile();
            Assert.AreNotEqual(triviaManager.GetRandomQuestion(5).Count, 3);
        }
    }
}
