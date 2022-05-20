using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuntTheWumpus.Trivia
{
    class TriviaManager
    {
        // not sure if i did this right tbh
        public List<Question> questions = new List<Question>();

        public TriviaManager()
        {

        }

        public void ReadFile()
        {
            // hopefully im doing this correctly
            using (StreamReader sr = new StreamReader("huntTheWumpusQuestions.txt"))
            {
                while (!sr.EndOfStream)
                {
                    // Random rnd = new Random();
                    string question = sr.ReadLine();
                }
            }
        }

        public void GetRandomQuestion(int num)
        {

        }
    }
}
