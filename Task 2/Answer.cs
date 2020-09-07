using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Answer
    {
        #region Fields
        public string answer;
        public bool isCorrect;
        #endregion

        #region Constructor
        public Answer()
        {

        }
        public Answer(string _answer, bool _isCorrect)
        {
            answer = _answer;
            isCorrect = _isCorrect;
        }
        #endregion
    }
}