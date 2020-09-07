using System;
using System.IO;
using FileJson;

namespace Exam
{
    class SelectDictionary 
    {
        #region Fields
        int choice;
        string user;
        DirectoryInfo directoryInfo;
        FileInfo[] files;
        Logic l;
        FileWR fj = new FileWR();
        #endregion

        #region Logic
        public void Run()
        {
            try
            {
                Console.WriteLine("Welcome to Dictionary\n");
                Menu();
                Console.Write("Enter Choice : ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        NewDictionary();

                        Console.Clear();

                        Run();
                        break;
                    case 2:
                        SelectExistDictionary();

                        Console.Clear();

                        Run();
                        break;
                    case 0:
                        stop();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Please select correct option.");
                        Console.ReadKey();
                        Console.Clear();
                        Run();

                        break;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e.Message);
                Console.ReadKey();
                Console.Clear();
                Run();
            }
        } //Complete
        #endregion

        #region Methods
        public int CheckDictionary()
        {
            directoryInfo = new DirectoryInfo(fj.dirpathDictionaryT1);
            files = directoryInfo.GetFiles();

            if (files.Length == 0)
            {
                return 0;
            }
            return 1;
        } //Complete
        public void Menu()
        {
            //Console.Clear();
            Console.WriteLine("1. Create new Dictionary");
            Console.WriteLine("2. Select Dictionary");
            Console.WriteLine("0. Exit");
        } //Complete
        public void stop()
        {
            Console.Clear();
            Console.Write("System Shutdown");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        } //Complete
        public void NewDictionary()
        {
            Console.Clear();
            Console.Write("Enter New Dictionary Name : ");
            user = Console.ReadLine();

            if (user == "")
            {
                Console.Clear();
                Console.Write("Please Enter Dictionary Name");
                Console.ReadKey();
                Console.Clear();
                NewDictionary();
            }
            else if (user == null)
            {
                stop();
            }
            else
            {
                string tpath = fj.dirpathDictionaryT1 + "\\" + user + ".json";
                File.WriteAllText(tpath, "");

                directoryInfo = new DirectoryInfo(fj.dirpathDictionaryT1);
                files = directoryInfo.GetFiles();
                Console.Clear();
                Console.Write("New Dictionary Created Successful");
                Console.ReadKey();
            }
        } //Complete
        public void SelectExistDictionary()
        {
            directoryInfo = new DirectoryInfo(fj.dirpathDictionaryT1);
            files = directoryInfo.GetFiles();

            if (files.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No Existing Dictionary Found!");
                Console.Write("Press any key to continues");
                Console.ReadKey();
                Console.Clear();
                Run();
            }
            else
            {
                Console.Clear();
                foreach (var i in files)
                {
                    Console.WriteLine("Dictionary : {0}", i.Name.Substring(0, i.Name.Length - i.Extension.Length));
                }

                Console.Write("Enter Dictionary Type : ");
                user = Console.ReadLine();

                bool sdsdd = false;

                foreach (var i in files)
                {
                    //var temp = i.Name.Substring(0, i.Name.Length - i.Extension.Length);
                    if (user.ToLower() == i.Name.Substring(0, i.Name.Length - i.Extension.Length).ToLower())
                    {
                        Console.Clear();
                        l = new Logic(user);
                        l.Play(user);
                        sdsdd = true;
                        break;
                    }
                }
                if (!sdsdd)
                {
                    Console.Clear();
                    Console.WriteLine("No Dictionary {0} Found!", user);
                    Console.Write("Press any key to continues");
                    Console.ReadKey();
                    SelectExistDictionary();
                }
            }
        } //Complete
        public void LoadDictionary(string quizname)
        {
            string path = fj.dirpathDictionaryT1 + "\\" + quizname + ".json";
            if (File.ReadAllText(path) == "")
            {
                l = new Logic();
            }
            else
            {
                l = fj.ReadObj(l, path);
            }
        } //Complete
        #endregion
    }
}