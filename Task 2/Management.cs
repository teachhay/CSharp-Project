using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileJson;

namespace Task_2
{
    class Management
    {
        #region Fields
        public List<Account> a;
        public List<QuizManagement> qm;
        public FileWR fj = new FileWR();
        private List<int> tscore = new List<int>();
        public Dictionary<string, int> Allscore = new Dictionary<string, int>();
        bool restart = true;
        private int index, day, month, year, j = 0, uScore = 0, choice;
        private string fname, lname, address, password, user, account = "", category = "";
        DirectoryInfo directoryInfo;
        FileInfo[] files;
        Management m;
        #endregion

        #region Account
        public void ShowAll()
        {
            foreach (var item in a)
            {
                Console.WriteLine("ID : {0}", item.id);
                Console.WriteLine("FName : {0}", item.fname);
                Console.WriteLine("LName : {0}", item.lname);
                Console.WriteLine("Dath of Birth : {0}/{1}/{2}", item.day, item.month, item.year);
                Console.WriteLine("Address : {0}", item.address);
                Console.WriteLine("Password : {0}", item.password);
                item.ShowScore();
            }
        } //Complete
        public void ShowScore(string fname)
        {
            if (fname == "")
            {
                Console.Write("Enter Name : ");
                fname = Console.ReadLine();
                ShowScore(fname);
            }
            else
            {
                foreach (var item in a)
                {
                    if (item.fname == fname)
                    {
                        item.ShowScore();
                        break;
                    }
                    else 
                    {
                        //Console.Clear();
                        //Console.WriteLine("Cannot Find Account : {0}", fname);
                    }
                }
            }
            Console.WriteLine();
        } //Complete
        public void ShowAccount(string account)
        {
            try
            {
                if (account == "")
                {
                    Console.Write("Enter Name : ");
                    account = Console.ReadLine();
                    ShowAccount(account);
                }
                else if (account != "")
                {
                    foreach (var item in a)
                    {
                        if (item.fname == account)
                        {
                            Console.Clear();
                            Console.WriteLine("ID : {0}", item.id);
                            Console.WriteLine("FName : {0}", item.fname);
                            Console.WriteLine("LName : {0}", item.lname);
                            Console.WriteLine("Dath of Birth : {0}/{1}/{2}", item.day, item.month, item.year);
                            Console.WriteLine("Address : {0}", item.address);
                            Console.WriteLine("Password : {0}", item.password);
                            item.ShowScore();
                        }                    
                        //}
                        //else
                        //{
                        //    Console.WriteLine();
                        //    Console.WriteLine("Cannot Find Account : {0}", account);
                        //    Console.WriteLine();
                        //}
                    }
                }
            }
            catch (Exception)
            {

            }
            Console.WriteLine();
        } //Complete
        public void AddAccount()
        {
            try
            {
                Console.Write("FName : ");
                fname = Console.ReadLine();
                Console.Write("LName : ");
                lname = Console.ReadLine();

                index = a.FindIndex(a => a.fname == fname);
                var findFName = a.Find(a => a.fname == fname);
                var findLName = a.Find(a => a.lname == lname);

                if (findFName.fname == fname && findLName.lname == lname)
                {
                    Console.WriteLine();
                    Console.WriteLine("Account name {0} {1} already exist", fname, lname);
                }
            }
            catch (Exception)
            {
                Console.Write("Day : ");
                day = int.Parse(Console.ReadLine());
                Console.Write("Month : ");
                month = int.Parse(Console.ReadLine());
                Console.Write("Year : ");
                year = int.Parse(Console.ReadLine());
                Console.Write("Address : ");
                address = Console.ReadLine();
                Console.Write("Password : ");
                password = Console.ReadLine();

                a.Add(new Account(fname, lname, day, month, year, address, password));
                Console.WriteLine("\nAccount Create Successful");
            }
            SaveAccount();
        } //Complete
        public void EditAccount(string fname)
        {
        Mark:
            if (fname == "")
            {
                Console.Write("Enter Name : ");
                fname = Console.ReadLine();
                goto Mark;
            }
            else if (fname != "")
            {
                Console.Clear();
                Console.WriteLine("1. Edit Password");
                Console.WriteLine("2. Edit Date of Birth");
                Console.Write("Enter Choice : ");
                choice = int.Parse(Console.ReadLine());

                foreach (var item in a)
                {
                    try
                    {
                        if (item.fname == fname && choice == 1)
                        {
                            Console.Clear();
                            Console.Write("Enter Password : ");
                            password = Console.ReadLine();
                            item.password = password;
                            Console.WriteLine();
                            Console.WriteLine("Successfully Updated Password\n");
                        }
                        else if (item.fname == fname && choice == 2)
                        {
                            Console.Clear();
                            Console.Write("Enter Day : ");
                            day = int.Parse(Console.ReadLine());
                            Console.Write("Enter Month : ");
                            month = int.Parse(Console.ReadLine());
                            Console.Write("Enter Year : ");
                            year = int.Parse(Console.ReadLine());
                            item.day = day;
                            item.month = month;
                            item.year = year;
                            Console.WriteLine();
                            Console.WriteLine("Successfully Updated Date of Birth\n");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                        Console.Clear();
                        EditAccount(account);
                    }
                }
            }
        } //Complete
        #endregion

        #region Quiz
        public void AddQuiz()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            if (files.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No Existing Quiz Found!");
                Console.WriteLine("Press any key to continues");
                Console.ReadKey();
                AdminMain();
            }
            else
            {
                Console.Clear();
                foreach (var i in files)
                {
                    Console.WriteLine("Quiz : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
                }

                Console.Write("Enter Quiz Name : ");
                string quizname = Console.ReadLine();
                LoadQuiz(quizname);
                Console.Clear();
                Console.Write("Enter Question : ");
                string question = Console.ReadLine();
                Console.Write("How many question to add? : ");
                int numAnswer = int.Parse(Console.ReadLine());

                Console.Clear();
                qm.Add(new QuizManagement(quizname, question));
                var find = qm.Find(a => a.id == qm.LastOrDefault().id);

                for (int i = 0; i < numAnswer; i++)
                {
                    if (find.id == qm.LastOrDefault().id)
                    {
                        Console.Clear();
                        Console.WriteLine("Question : {0}", question);
                        Console.WriteLine("Answer : {0}", i + 1);
                        find.Answer();
                        Console.Clear();
                        Console.WriteLine("New Quiz Added\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not Found\n");
                    }
                }
                SaveQuiz(quizname);
            }
        } //Complete
        public void AddAnswer()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            if (files.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No Existing Quiz Found!");
                Console.WriteLine("Press any key to continues");
                Console.ReadKey();
                AdminMain();
            }
            else
            {
                Console.Clear();
                foreach (var i in files)
                {
                    Console.WriteLine("Quiz : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
                }

                Console.Write("Enter Quiz Name : ");
                string quizname = Console.ReadLine();
                LoadQuiz(quizname);

                Console.Clear();

                j = 0;
                foreach (var i in qm)
                {
                    j++;
                    Console.WriteLine("{0} - Question : {1}", j, i.question);
                }

                Console.Write("Enter ID : ");
                int choice = int.Parse(Console.ReadLine());

                var find = qm.Find(a => a.id == choice);

                if (find.id == choice)
                {
                    Console.Clear();
                    find.Answer();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not Found");
                }
                SaveQuiz(quizname);
            }
        } //Complete
        public void EditQuiz()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            if (files.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No Existing Quiz Found!");
                Console.WriteLine("Press any key to continues");
                Console.ReadKey();
                AdminMain();
            }
            else
            {
                Console.Clear();
                foreach (var i in files)
                {
                    Console.WriteLine("Quiz : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
                }

                Console.Write("Enter Quiz Name : ");
                string quizname = Console.ReadLine();
                LoadQuiz(quizname);

                Console.Clear();
                
                j = 0;
                foreach (var i in qm)
                {
                    j++;
                    Console.WriteLine("{0} - Question : {1}", j, i.question);
                }

                Console.Write("Enter ID : ");
                int choice = int.Parse(Console.ReadLine());

                var find = qm.Find(a => a.id == choice);

                if (find.id == choice)
                {
                    Console.Clear();
                    Console.WriteLine("Old Question : {0}", find.question);
                    Console.Write("Enter New Question : ");
                    string inputquestion = Console.ReadLine();
                    find.question = inputquestion;
                    Console.Clear();
                    Console.WriteLine("New Question Updated");
                }
                SaveQuiz(quizname);
            }
            Console.WriteLine();
        } //Complete
        public void EditAnswer()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            if (files.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No Existing Quiz Found!");
                Console.WriteLine("Press any key to continues");
                Console.ReadKey();
                AdminMain();
            }
            else
            {
                Console.Clear();
                foreach (var i in files)
                {
                    Console.WriteLine("Quiz : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
                }

                Console.Write("Enter Quiz Name : ");
                string quizname = Console.ReadLine();
                LoadQuiz(quizname);

                Console.Clear();

                j = 0;
                foreach (var i in qm)
                {
                    j++;
                    Console.WriteLine("{0} - Question : {1}", j, i.question);
                }

                Console.Write("Enter ID : ");
                int choice = int.Parse(Console.ReadLine());

                var find = qm.Find(a => a.id == choice);

                if (find.id == choice)
                {
                    Console.Clear();
                    find.EditAnswer();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not Found");
                }
                SaveQuiz(quizname);
                Console.WriteLine();
            }
        } //Complete
        public void ShowQuiz()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            foreach (var i in files)
            {
                Console.WriteLine("Quiz : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
            }

            Console.Write("Enter Choice : ");
            string temp = Console.ReadLine();

            LoadQuiz(temp);

            Console.Clear();
            if(qm.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("No Question exist in selected Quiz");
                Console.WriteLine("Please add question to the Quiz first\n");
            }
            else
            {
                foreach (var j in qm)
                {
                    Console.WriteLine("ID : {0}, Question : {1}", j.id, j.question);
                    j.ShowAnswerAdmin();
                    Console.WriteLine();
                }
            }
        } //Complete
        #endregion

        #region Logic
        public void Play()
        {
            tscore.Clear();
            Allscore.Clear();

            Console.Clear();
            foreach (var i in qm)
            {
            Mark:
                try
                {
                    Console.WriteLine("Question {0} : {1}", i.id, i.question);
                    i.ShowAnswer();

                    Console.WriteLine();
                    Console.Write("Enter Choice : ");
                    int userAnswer = int.Parse(Console.ReadLine());

                    if (userAnswer > 0 && userAnswer < i.answers.Count() + 1)
                    {
                        if (i.Check() + 1 == userAnswer)
                        {
                            int h = 0;
                            tscore.Add(h);
                            Console.WriteLine("Correct");
                        }
                        else
                        {
                            Console.WriteLine("Not Correct");
                            Console.WriteLine("Correct Answer is Answer #{0}", i.Check() + 1);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Select answer according to number");
                        Console.ReadKey();
                        Console.Clear();
                        goto Mark;
                    }
                    Console.Write("Press any key to continues");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.Clear();
                    goto Mark;
                }
            }

            Console.WriteLine("Quiz Complete");
            
            uScore = tscore.Count * 5;
            Console.WriteLine("Your Score : {0}", uScore);

            Console.WriteLine();
            Console.WriteLine("LeaderBoard");

            var uAccount = a.Find(a => a.fname == account);
            uAccount.score.Add(uScore);
            Allscore.Add(uAccount.fname, uScore);

            Score();

            SaveAccount();
        } //Complete
        public void NewQuizCategory()
        {
            Console.Clear();
            Console.Write("Enter New Quiz Name : ");
            string quizname = Console.ReadLine();

            string tpath = fj.dirQuiz + "\\" + quizname + ".json";
            File.WriteAllText(tpath, "");
            Console.Clear();
            Console.WriteLine("New Quiz Category created succesful\n");
        } //Complete
        public void Uplay()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            if (files.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No Existing Quiz Found!");
                Console.Write("Press any key to continues");
                Console.ReadKey();
                Console.Clear();
                UserMain(account);
            }
            else
            {
                Console.Clear();
                foreach (var i in files)
                {
                    Console.WriteLine("Quiz Category : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
                }

                Console.Write("Enter Quiz Category : ");
                user = Console.ReadLine();

                bool sdsdd = false;

                foreach (var i in files)
                {
                    var temp = i.Name.Substring(0, i.Name.Length - i.Extension.Length);
                    if (user.ToLower() == temp.ToLower())
                    {
                        LoadQuiz(user);
                        Play();
                        sdsdd = true;
                        break;
                    }
                }
                if (!sdsdd)
                {
                    Console.Clear();
                    Console.WriteLine("no quiz {0} found!", user);
                    Console.WriteLine("press any key to continues\n");
                }
            }
        } //Complete
        public void stop()
        {
            Console.Clear();
            Console.WriteLine("System Shutdown");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        } //Complete
        private void goback()
        {
            Console.WriteLine("9. Exit");
            Console.WriteLine("0. goback");
            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.Clear();
                UserMain(account);
            }
            else
            {
                stop();
            }
        } //Complete
        private void gobackAdmin()
        {
            Console.WriteLine("9. Exit");
            Console.WriteLine("0. goback");
            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.Clear();
                AdminMain();
            }
            else
            {
                stop();
            }
        } //Complete
        public void SaveAccount()
        {
            fj.WriteObj<Account>(a, fj.pathAcc);
        } //Complete
        public void LoadAccount()
        {
            a = fj.ReadObj(a, fj.pathAcc).ToList();
        } //Complete
        public void SaveQuiz(string quizname)
        {
            string path = fj.dirQuiz + "\\" + quizname + ".json";
            fj.WriteObj<QuizManagement>(qm, path);
        } //Complete
        public void LoadQuiz(string quizname)
        {
            string path = fj.dirQuiz + "\\" + quizname + ".json";
            if (File.ReadAllText(path) == "")
            {
                qm = new List<QuizManagement>();
            }
            else
            {
                qm = fj.ReadObj(qm, path).ToList();
            }
        } //Complete
        public void Score()
        {
            foreach (var i in a)
            {
                if (i.fname != account)
                {
                    Allscore.Add(i.fname, i.Score());
                }
            }

            var rand = new Random();
            Allscore.Add("Zack", rand.Next(1, 101));
            Allscore.Add("Ivy", rand.Next(1, 101));
            Allscore.Add("Kim", rand.Next(1, 101));
            Allscore.Add("Usher", rand.Next(1, 101));
            Allscore.Add("Vandale", rand.Next(1, 101));
            Allscore.Add("Rose", rand.Next(1, 101));
            Allscore.Add("Lyly", rand.Next(1, 101));
            Allscore.Add("Ryan", rand.Next(1, 101));
            Allscore.Add("William", rand.Next(1, 101));
            Allscore.Add("Hawk", rand.Next(1, 101));

            var mylist = Allscore.ToList();

            mylist.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            mylist.Reverse();

            foreach (var i in mylist)
            {
                Console.WriteLine("{0} : {1}", i.Key, i.Value);
            }
            Console.WriteLine();
        } //Complete
        public void Random()
        {
            Console.Clear();
            Allscore.Clear();

            var rand = new Random();

            Allscore.Add("Zack", rand.Next(1, 101));
            Allscore.Add("Ivy", rand.Next(1, 101));
            Allscore.Add("Kim", rand.Next(1, 101));
            Allscore.Add("Usher", rand.Next(1, 101));
            Allscore.Add("Vandale", rand.Next(1, 101));
            Allscore.Add("Rose", rand.Next(1, 101));
            Allscore.Add("Lyly", rand.Next(1, 101));
            Allscore.Add("Ryan", rand.Next(1, 101));
            Allscore.Add("William", rand.Next(1, 101));
            Allscore.Add("Hawk", rand.Next(1, 101));

            Allscore.Add("John", rand.Next(1, 101));
            Allscore.Add("Grace", rand.Next(1, 101));
            Allscore.Add("Jane", rand.Next(1, 101));
            Allscore.Add("David", rand.Next(1, 101));
            Allscore.Add("King", rand.Next(1, 101));
            Allscore.Add("Lara", rand.Next(1, 101));
            Allscore.Add("Harry", rand.Next(1, 101));
            Allscore.Add("CaptainCold", rand.Next(1, 101));
            Allscore.Add("Duke", rand.Next(1, 101));
            Allscore.Add("Cortana", rand.Next(1, 101));

            var myList = Allscore.ToList();

            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            myList.Reverse();

            foreach (var i in myList)
            {
                Console.WriteLine("{0} : {1}", i.Key, i.Value);
            }
            Console.WriteLine();
        } //Complete
        public void Top20()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            foreach (var i in files)
            {
                Console.WriteLine("Quiz : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
            }

            Console.Write("Enter Choice : ");
            string temp = Console.ReadLine();

            LoadQuiz(temp);

            Console.Clear();
            if (qm.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("No Question exist in selected Quiz");
                Console.WriteLine("Please add question to the Quiz first\n");
            }
            else
            {
                Random();
            }
        } //Complete
        public void MixQuiz()
        {
            directoryInfo = new DirectoryInfo(fj.dirQuiz);
            files = directoryInfo.GetFiles();

            bool t = true;

            foreach (var i in files)
            {
                var tquiz = i.Name.Substring(0, i.Name.Length - i.Extension.Length);
                Console.WriteLine(tquiz);
                if(tquiz != "MixQuiz")
                {
                    qm = fj.ReadObj(qm, i.FullName).ToList();
                }
            }

            Console.WriteLine();

            foreach (var j in qm)
            {
                Console.WriteLine("ID : {0}, Question : {1}", j.id, j.question);
                j.ShowAnswerAdmin();
                Console.WriteLine();
            }
        } //In Progress
        #endregion

        #region Management
        public void AdminMain()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome to Admin Quiz Console\n");
                Console.WriteLine("1. Create New Quiz Category");
                Console.WriteLine("2. Add Quiz in Existing Category");
                Console.WriteLine("3. Add Answer in Existing Quiz");
                Console.WriteLine("4. Edit Quiz in Existing Category");
                Console.WriteLine("5. Edit Answer in Existing Quiz");
                Console.WriteLine("6. Show Specific Quiz");
                Console.WriteLine("7. Logout");
                Console.WriteLine("8. Exit");
                Console.Write("Enter Choice : ");
                int choice = int.Parse(Console.ReadLine());

                while (restart != false)
                {
                    switch (choice)
                    {
                        case 1: //Create new Quiz
                            Console.Clear();

                            NewQuizCategory();

                            gobackAdmin();
                            break;
                        case 2: //Add Quiz to Category
                            Console.Clear();

                            AddQuiz();

                            gobackAdmin();
                            break;
                        case 3: //Add Answer to Quiz
                            Console.Clear();

                            AddAnswer();

                            gobackAdmin();
                            break;
                        case 4: //Edit Quiz
                            Console.Clear();

                            EditQuiz();

                            gobackAdmin();
                            break;
                        case 5: //Edit Quiz
                            Console.Clear();

                            EditAnswer();

                            gobackAdmin();
                            break;
                        case 6: //Show Quiz
                            Console.Clear();

                            ShowQuiz();

                            gobackAdmin();
                            break;
                        case 7: //Logout
                            Console.Clear();
                            restart = false;
                            break;
                        case 8: //Exit
                            stop();
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
                AdminMain();
            }
        } //Complete
        public void UserMain(string _account)
        {
            try
            {
                this.account = _account;
                Console.WriteLine("Welcome to Quiz, {0}\n", account);
                Console.WriteLine("1. Start Quiz");
                Console.WriteLine("2. View Previous Result");
                Console.WriteLine("3. View Top 20 in Specific Quiz");
                Console.WriteLine("4. Show Profile");
                Console.WriteLine("5. Change Setting");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit");
                Console.Write("Your Choise : ");
                int user = int.Parse(Console.ReadLine());

                while (restart != false)
                {
                    switch (user)
                    {
                        case 1:
                            Uplay();

                            goback();
                            break;
                        case 2:
                            Console.Clear();
                            ShowScore(account);

                            goback();
                            break;
                        case 3:
                            Console.Clear();

                            Top20();

                            goback();
                            break;
                        case 4:
                            Console.Clear();
                            ShowAccount(account);

                            goback();
                            break;
                        case 5:
                            Console.Clear();
                            EditAccount(account);

                            goback();
                            break;
                        case 6:
                            restart = false;
                            Console.Clear();
                            break;
                        case 7:
                            stop();
                            break;
                        case 8:
                            Console.Clear();

                            Random();

                            goback();
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
                UserMain(account);
            }
        } //Complete
        #endregion

        #region Constructor
        public Management()
        {
            #region Final
            if (File.ReadAllText(fj.pathAcc) == "")
            {
                a = new List<Account>();
            }
            else
            {
                a = fj.ReadObj(a, fj.pathAcc).ToList();
            }
            #endregion

            #region New Version
            //if (!Directory.Exists(dir))
            //{
            //    Directory.CreateDirectory(path);
            //}

            //path2 = path + "\\" + dic + ".json";
            //if (File.ReadAllText(path) == "")
            //    qm = new List<QuizManagement>();
            //else
            //{
            //    qm = fj.ReadObj(qm, path).ToList();
            //}
            #endregion

            #region Old Version
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", true), new Answer("Math", false), new Answer("Physis", false), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", true), new Answer("Physis", false), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", false), new Answer("English", true), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", true), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", true), new Answer("Physis", false), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", true), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", true), new Answer("Physis", false), new Answer("English", true), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", false), new Answer("English", true), }));

            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", true), new Answer("Math", false), new Answer("Physis", false), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", true), new Answer("Physis", false), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", false), new Answer("English", true), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", true), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", true), new Answer("Physis", false), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", true), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", true), new Answer("Physis", false), new Answer("English", true), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", true), new Answer("English", false), }));
            //qm.Add(new QuizManagement("History", "What is Math", new List<Answer>() { new Answer("History", false), new Answer("Math", false), new Answer("Physis", false), new Answer("English", true), }));
            #endregion
        }
        public Account this[string _name]
        {
            get
            {
                foreach (var e in a)
                {
                    if (e.fname == _name)
                    {
                        return e;
                    }
                }
                return null;
            }
        }  //Complete
        #endregion
    }
}