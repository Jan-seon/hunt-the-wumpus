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
        public List<Question> Questions = new List<Question>();

        public TriviaManager()
        {

        }

        public void ReadFile()
        {
            using (StreamReader sr = new StreamReader("huntTheWumpusQuestions.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string question = sr.ReadLine();
                    string[] data = question.Split(',');
                    string tq = data[0];
                    string a = data[1];
                    string b = data[2];
                    string c = data[3];
                    string d = data[4];
                    string ans = data[5];

                    Question q = new Question(tq, a, b ,c, d, ans);
                    Questions.Add(q);
                }
            }
        }

        public void GetRandomQuestion(int num)
        {

        }
    }
}
