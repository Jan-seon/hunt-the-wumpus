using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus.Trivia
{
    public class Question
    {
        public string TriviaQuestion { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer { get; set; }
        
        //TODO: I (Mr Fernandez) changed this because I think you had the values flipped
        //Example: tq = TriviaQuestion, instead of "TriviaQuestion = tq"
        public Question(string tq, string a, string b, string c, string d, string ans)
        {
            TriviaQuestion = tq;
            OptionA = a;
            OptionB = b;
            OptionC = c;
            OptionD = d;
            Answer = ans;
        }

        public bool CheckAnswer(string guess)
        {
            return guess == Answer;
        }
    }
}
