using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileJson;

namespace Task_2
{
    class QuizManagement
    {
        #region Fields        
        static public int j = 1;
        public int id = 0;
        public string category;
        public string question;
        public List<Answer> answers = new List<Answer>();
        private List<QuizManagement> qm = new List<QuizManagement>();
        public FileWR fj = new FileWR();
        #endregion

        #region  Methods
        public void Answer()
        {
            Console.Write("Enter Answer: ");
            string user = Console.ReadLine();

            Console.WriteLine("Is this the correct answer? y/n");
            string correct = Console.ReadLine();
            if (correct == "yes" || correct == "y" || correct == "Yes" || correct == "Y")
            {
                answers.Add(new Answer(user, true));
            }
            else
            {
                answers.Add(new Answer(user, false));
            }
            Console.Clear();
            Console.WriteLine("New Answer Added\n");
        }
        public void EditAnswer()
        {
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine("{0} - Answer : {1}", i + 1, answers[i].answer);
            }

            j = 0;
            Console.Write("Select : ");
            j = int.Parse(Console.ReadLine());

            for (int l = 0; l < answers.Count; l++)
            {
                if (j - 1 == l)
                {
                    Console.Clear();
                    Console.Write("Enter New Answers : ");
                    string inputanswer = Console.ReadLine();
                    Console.WriteLine("Is this the correct answer? y/n");
                    string correct = Console.ReadLine();
                    if (correct == "yes" || correct == "y" || correct == "Yes" || correct == "Y")
                    {
                        answers[l].answer = inputanswer;
                        answers[l].isCorrect = true;
                    }
                    else
                    {
                        answers[l].answer = inputanswer;
                        answers[l].isCorrect = false;
                    }

                }
            }
            Console.Clear();
            Console.WriteLine("New Answer Updated");
        }
        public void ShowAnswerAdmin()
        {
            j = 0;
            foreach (var i in answers)
            {
                j++;
                if (i.isCorrect == true)
                {
                    Console.WriteLine("Answer {0} : {1} | Correct : {2}", j, i.answer, "yes");
                }
                else
                {
                    Console.WriteLine("Answer {0} : {1}", j, i.answer);
                }
            }
        }
        public void ShowAnswer()
        {
            j = 0;
            foreach (var i in answers)
            {
                j++;
                Console.WriteLine("Answer {0} : {1}", j, i.answer);
            }
        }
        public int Check()
        {
            return answers.FindIndex(a => a.isCorrect == true);
        }
        #endregion

        #region Constructor
        public QuizManagement()
        {
            answers = new List<Answer>();
        }
        public QuizManagement(string _category, string _question, List<Answer> _answers)
        {
            this.id = j++;
            this.category = _category;
            this.question = _question;
            answers = _answers;
            //answers.Add(new Answer(_answers, _isCorrect));
        }
        public QuizManagement(string _category, string _question)
        {
            string path = fj.dirQuiz + "\\" + _category + ".json";
            if (File.ReadAllText(path) == "")
            {
                this.id = j++;
                this.category = _category;
                this.question = _question;
            }
            else
            {
                qm = fj.ReadObj(qm, path).ToList();
                this.id = qm.Count;
                this.category = _category;
                this.question = _question;
            }
        }
        #endregion
    }
}