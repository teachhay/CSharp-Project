using System;
using System.IO;
using FileJson;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    class SelectQuiz
    {
        #region Old Version
        //static private string userName = Environment.UserName;
        //public string dir = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2", userName);
        //public string dirpath = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2", userName);
        //public string dirpathQui = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Quiz", userName);
        //public string dirpathAcc = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Account", userName);
        //public string path = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Quiz\Quiz.json", userName);
        //public string path2 = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2", userName);
        //public string pathAcc = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Account\Account.json", userName);
        //private List<Account> a;
        //private FileWR fj;
        //private Management m;
        #endregion

        #region New Version
        #region Fields
        private List<Account> a;
        private Management m;
        private FileWR fj;
        #endregion

        #region Methods
        public void stop()
        {
            Console.Clear();
            Console.WriteLine("System Shutdown");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        } //Complete
        private void goback()
        {
            Console.WriteLine("\n9. Exit");
            Console.WriteLine("0. goback");
            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.Clear();
                Run();
            }
            else
            {
                stop();
            }
        } //Complete
        public void Login()
        {
            bool temp = true;

            if (File.ReadAllText(fj.pathAcc) == "")
            {
                Console.Write("Enter Name : ");
                string admin = Console.ReadLine();
                Console.Write("Enter Password : ");
                string password = Console.ReadLine();
                if(admin == "admin" && password == "admin")
                {
                    m.AdminMain();
                    Run();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No Account Exist");
                    Console.WriteLine("Please Create Account");

                    goback();
                }
            }
            else
            {
                Console.Clear();
                FindAcount();
                Console.Write("Enter Name : ");
                string username = Console.ReadLine();

                foreach (var i in a)
                {
                    if (username == i.fname)
                    {
                        Account(username);
                        m.UserMain(username);
                        temp = true;
                        break;
                    }
                    else if (username == "admin")
                    {
                        Console.Write("Enter Password : ");
                        string password = Console.ReadLine();
                        if (password == "admin")
                        {
                            m.AdminMain();
                            Run();
                        }
                    }
                    else
                    {
                        temp = false;
                    }
                }
                if (temp == false)
                {
                    Console.Write("Enter Password : ");
                    string password = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Invalid Username or Password");
                    Console.WriteLine("Please try again!");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    Run();
                }
            }
        } //Complete
        public void FindAcount()
        {
            if (File.ReadAllText(fj.pathAcc) == "")
            {
                a = new List<Account>();
            }
            else
            {
                a = fj.ReadObj(a, fj.pathAcc).ToList();
            }
        } //Complete
        public void CreateAccount()
        {
            try
            {
                m.AddAccount();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
                CreateAccount();
            }
        } //Complete
        public void Account(string username)
        {
            var tuser = a.Find(p => p.fname == username);

            Console.Write("Enter Password : ");
            string password = Console.ReadLine();

            if (tuser.fname == username && tuser.password == password)
            {
                Console.Clear();
                //Console.WriteLine("Login Success");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Username or Password");
                Console.WriteLine("Please try again!");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                Run();
            }
        } //Complete
        #endregion

        #region Runtime
        public void Run()
        {
            #region Old Version
            //try
            //{
            //    Console.Clear();
            //    m = new Management();
            //    a = new List<Account>();
            //    Console.WriteLine("1. Login");
            //    Console.WriteLine("2. Create Account");
            //    Console.Write("Enter Choice : ");
            //    int choice = int.Parse(Console.ReadLine());
            //    switch (choice)
            //    {
            //        case 1:
            //            Console.Clear();
            //            Login();

            //            Run();
            //            //goback();
            //            break;
            //        case 2:
            //            Console.Clear();
            //            CreateAccount();

            //            goback();
            //            break;
            //    }
            //}
            //catch (Exception)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Please Enter number only");
            //    Console.WriteLine("Press any key to continue");
            //    Console.ReadKey();
            //    Console.Clear();
            //    Run();
            //}
            #endregion

            try
            {
                Console.Clear();
                m = new Management();
                a = new List<Account>();
                Console.WriteLine("Welcome to Quiz\n");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create Account");
                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice : ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Login();

                        Run();
                        break;
                    case 2:
                        Console.Clear();
                        CreateAccount();

                        goback();
                        break;
                    case 0:
                        stop();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter number accroding to the menu");
                        Console.ReadKey();
                        Run();
                        break;
                }
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("Please enter number accroding to the menu");
                Console.ReadKey();
                Run();
            }
        }
        #endregion

        #region Constructor
        public SelectQuiz()
        {
            fj = new FileWR();
            //m = new Management();
        }
        #endregion
        #endregion
    }
}