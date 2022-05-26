using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuntTheWumpus.Trivia
{
    public class TriviaManager
    {
        public List<Question> Questions = new List<Question>();

        public TriviaManager()
        {
            ReadFile();
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

        public List<Trivia.Question> GetRandomQuestion(int num)
        {
            List<Trivia.Question> qList = new List<Trivia.Question>();

            int placeholder = 15;

            for (int i = 0; i < num; i++)
            {
                Random rnd = new Random();
                int qNum = rnd.Next(0, placeholder);

                qList.Add(Questions[qNum]);
            }
            return qList;
        }
    }
}
