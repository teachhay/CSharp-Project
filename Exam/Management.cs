using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using FileJson;

namespace Exam
{
    class Logic
    {
        #region Old Version Fields
        //public List<MyDictionary> t;
        //private int index, q = 0;
        //private string dictionary = "", word, definition;
        //static private string userName = Environment.UserName;
        //private string path2 = String.Format(@"C:\Users\{0}\Desktop\Exam\data.json", userName);
        //private string path = String.Format(@"C:\Users\{0}\Desktop\Exam", userName);
        //private string path3 = String.Format(@"C:\Users\{0}\Desktop\Exam\Export", userName);
        //public FileWR fj = new FileWR();
        //DirectoryInfo directoryInfo;
        //FileInfo[] files;
        #endregion

        #region Fields
        public List<MyDictionary> t;
        public FileWR fj = new FileWR();
        private int index;
        private string word, definition, dictionary = "";
        #endregion

        #region Methods 
        private void temp()
        {
            Console.WriteLine("\nCannot found word : {0}", word);
        } //Complete
        private void NewDefiniation()
        {
            try
            {
                Console.Write("Enter Word: ");
                word = Console.ReadLine();

                index = t.FindIndex(a => a.word == word);
                var find = t.Find(a => a.word.ToLower() == word.ToLower());

                if (find.word.ToLower() == word.ToLower())
                {
                    find.AddDef();

                    Console.Clear();
                    Console.WriteLine("New Word {0} definition added", word);
                }
                else
                {
                    temp();
                }
            }
            catch (Exception)
            {
                temp();
            }
            SaveDictionary(dictionary);
            Console.WriteLine();
        } //Complete
        private void NewWord()
        {
            try
            {
                Console.Write("Enter Word: ");
                word = Console.ReadLine();

                var find = t.Find(a => a.word.ToLower() == word.ToLower());

                if (find.word.ToLower() == word.ToLower())
                {
                    Console.WriteLine();
                    Console.WriteLine("Word {0} already exist", word);
                }
            }
            catch (Exception)
            {
                Console.Write("Enter Definition: ");
                definition = Console.ReadLine();
                t.Add(new MyDictionary(word, definition));

                Console.Clear();
                Console.WriteLine("New Word {0} added", word);
            }
            SaveDictionary(dictionary);
            Console.WriteLine();
        } //Complete
        private void EditWord()
        {
            try
            {
                Console.Write("Enter Word: ");
                word = Console.ReadLine();
                int index = t.FindIndex(a => a.word == word);

                var find = t.Find(a => a.word.ToLower() == word.ToLower());
                if (find.word.ToLower() == word.ToLower())
                {
                    Console.WriteLine("Current Word : {0}", find.word);
                    Console.Write("Enter New Word: ");
                    string newword = Console.ReadLine();
                    t[index].word = newword;
                    Console.Clear();
                    Console.WriteLine("\nWord {0} updated to {1}", word, newword);
                }
                else
                {
                    temp();
                }
            }
            catch (Exception)
            {
                temp();
            }
            SaveDictionary(dictionary);
            Console.WriteLine();
        } //Complete
        private void EditDefinition()
        {
            try
            {
                Console.Write("Enter Word: ");
                word = Console.ReadLine();
                int index = t.FindIndex(a => a.word.ToLower() == word.ToLower());

                var find = t.Find(a => a.word.ToLower() == word.ToLower());
                if (find.word.ToLower() == word.ToLower())
                {
                    Console.Clear();
                    find.EditDef(find.word);
                }
                else
                {
                    temp();
                }
            }
            catch (Exception)
            {
                temp();
            }

            SaveDictionary(dictionary);
            Console.WriteLine();
        } //Complete
        private void DeleteWord()
        {
            try
            {
                Console.Write("Enter Word: ");
                word = Console.ReadLine();
                int index = t.FindIndex(a => a.word.ToLower() == word.ToLower());
                t.RemoveAt(index);

                Console.Clear();
                Console.WriteLine("Word {0} deleted", word);
            }
            catch (Exception)
            {

                temp();

            }
            SaveDictionary(dictionary);
            Console.WriteLine();
        } //Complete
        private void DeleteDefinition()
        {
            try
            {
                Console.Write("Enter Word: ");
                word = Console.ReadLine();
                int index = t.FindIndex(a => a.word == word);

                var find = t.Find(a => a.word.ToLower() == word.ToLower());
                if (find.word.ToLower() == word.ToLower())
                {
                    Console.Clear();
                    find.DeleteDef();
                }
                else
                {
                    temp();
                }
            }
            catch (Exception)
            {
                temp();
            }
            SaveDictionary(dictionary);
            Console.WriteLine();
        } //Complete
        private void Show()
        {
            LoadDictionary(dictionary);

            if(t.Count == 0)
            {
                Console.WriteLine("No Word exist, Please create first\n");
            }
            else
            {
                foreach (var item in t)
                {
                    Console.WriteLine("Word : {0}", item.word);
                    item.ShowDef();
                    Console.WriteLine();
                }
            }
        } //Complete
        private void ShowExport()
        {
            LoadDictionary(dictionary);

            if (t.Count == 0)
            {
                Console.WriteLine("No Word exist, Please create first\n");
            }
            else
            {
                foreach (var item in t)
                {
                    Console.WriteLine("Word : {0}", item.word);
                }
            }
        } //Complete
        private void Search()
        {
            if (t.Count == 0)
            {
                Console.WriteLine("No Word exist, Please Create first");
            }
            else
            {
                try
                {
                    Console.Write("Word to search : ");
                    word = Console.ReadLine();

                    var find = t.Find(a => a.word.ToLower() == word.ToLower());

                    if (find.word.ToLower() == word.ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("Word : {0}", find.word);
                        find.ShowDef();
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Word {0} cannot found", word);
                }
            }
            Console.WriteLine();
        } //Complete
        private void Export()
        {
            if (!Directory.Exists(fj.dirpathExportT1))
                Directory.CreateDirectory(fj.dirpathExportT1);

            DirectoryInfo directoryInfo = new DirectoryInfo(fj.dirpathExportT1);
            FileInfo[] files = directoryInfo.GetFiles();

            if(t.Count == 0)
            {
                Console.WriteLine("No Word exist, Please create first\n");
            }
            else
            {
                ShowExport();
                string tpath = fj.dirpathExportT1 + "\\ExportData" + (files.Length + 1) + ".json";
                try
                {
                    Console.Write("Select word to export : ");
                    word = Console.ReadLine();

                    var find = t.Find(a => a.word.ToLower() == word.ToLower());

                    if (find.word.ToLower() == word.ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("Selected Word {0} exported to path : {1}", find.word, tpath);
                        Console.WriteLine();
                        fj.WriteFile(find, tpath);
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Word {0} cannot found", word);
                }
            }
        } //Complete
        #endregion

        #region Logic
        private void stop()
        {
            Console.Clear();
            Console.Write("System Shutdown");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        } //Complete
        private void Menu()
        {
            Console.WriteLine("1. Add Word");
            Console.WriteLine("2. Edit Word");
            Console.WriteLine("3. Delete Word");
            Console.WriteLine("4. Search Word");
            Console.WriteLine("5. Export word to file");
            Console.WriteLine("6. Show All");
            Console.WriteLine("7. Back to Main Menu");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Choice : ");
        } //Complete
        private void SaveDictionary(string _dictionary)
        {
            string path = fj.dirpathDictionaryT1 + "\\" + _dictionary + ".json";
            fj.WriteObj<MyDictionary>(t, path);
        } //Complete
        private void LoadDictionary(string _dictionary)
        {
            string path = fj.dirpathDictionaryT1 + "\\" + _dictionary + ".json";
            if (File.ReadAllText(path) == "")
            {
                t = new List<MyDictionary>();
            }
            else
            {
                t = fj.ReadObj(t, path);
            }
        } //Complete
        public void Play(string _dictionary)
        {
            try
            {
                LoadDictionary(_dictionary);
                Console.Clear();
                this.dictionary = _dictionary;
                Console.WriteLine("Welcome to {0} Dictionary\n", dictionary);
                Menu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Add();

                        goback();
                        break;
                    case 2:
                        Console.Clear();

                        Edit();

                        goback();
                        break;
                    case 3:
                        Console.Clear();

                        Delete();

                        goback();
                        break;
                    case 4:
                        Console.Clear();

                        Search();

                        goback();
                        break;
                    case 5:
                        Console.Clear();

                        Export();

                        goback();
                        break;
                    case 6:
                        Console.Clear();

                        Show();

                        goback();
                        break;
                    case 7: //Logout

                        break;
                    case 8:
                        Console.Clear();

                        stop();

                        goback();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Please select correct option.");
                        Console.ReadKey();
                        Console.Clear();
                        Play(dictionary);

                        break;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e.Message);
                Console.ReadKey();
                Console.Clear();
                Play(dictionary);
            }
        } //Complete
        private void goback()
        {
            try
            {
                Console.WriteLine("9. Exit");
                Console.WriteLine("0. Back");
                Console.Write("Enter Choice : ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Play(dictionary);
                        break;
                    case 9:
                        stop();
                        break;
                    default:
                        goback();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
                goback();
            }
        } //Complete
        private void Add()
        {
            try
            {
                Console.WriteLine("1. Add New Word");
                Console.WriteLine("2. Add New Definition to Existing Word");
                Console.Write("Enter Choice : ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        NewWord();
                        break;
                    case 2:
                        Console.Clear();
                        NewDefiniation();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Please select correct option.");
                        Console.ReadKey();
                        Console.Clear();
                        Add();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e.Message);
                Console.ReadKey();
                Console.Clear();
                Add();
            }
        } //Complete
        private void Edit()
        {
            if (t.Count == 0)
            {
                Console.WriteLine("No Word exist, Please create first\n");
            }
            else
            {
                try
                {
                    Console.WriteLine("1. Edit Word");
                    Console.WriteLine("2. Edit Definition");
                    Console.Write("Enter Choice : ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            EditWord();
                            break;
                        case 2:
                            Console.Clear();
                            EditDefinition();
                            break;
                        default:
                            Console.Clear();
                            Console.Write("Please select correct option.");
                            Console.ReadKey();
                            Console.Clear();
                            Edit();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.Write(e.Message);
                    Console.ReadKey();
                    Console.Clear();
                    Edit();
                }
            }
        } //Complete
        private void Delete()
        {
            if(t.Count == 0)
            {
                Console.WriteLine("No Word exist, Please create first\n");
            }
            else
            {
                try
                {
                    Console.WriteLine("1. Delete Word");
                    Console.WriteLine("2. Delete Definition");
                    Console.Write("Enter Choice : ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            DeleteWord();
                            break;
                        case 2:
                            Console.Clear();
                            DeleteDefinition();
                            break;
                        default:
                            Console.Clear();
                            Console.Write("Please select correct option.");
                            Console.ReadKey();
                            Console.Clear();
                            Delete();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.Write(e.Message);
                    Console.ReadKey();
                    Console.Clear();
                    Edit();
                }
            }
        } //Complete
        #endregion

        #region Constructors
        public Logic()
        {

        } //Complete
        public Logic(string dictionary)
        {
            #region Old Version
            ///* if it ain't broke, don't fix it */
            //if (File.Exists(path))
            //{
            //    var lineCount = File.ReadLines(path).Count();
            //    var lines = File.ReadAllLines(path);
            //    string[] words = lines;

            //    t = new List<MyDictionary>(lineCount);
            //    for (int i = 0; i < lineCount / 2; i++)
            //    {
            //        t.Add(new MyDictionary(words[i + i], words[i + i + 1]));
            //    }
            //}
            //else
            //{
            //    t = new List<MyDictionary>
            //    {
            //        new MyDictionary("car", "vehicle"),
            //        new MyDictionary("human", "people"),
            //    };
            //}
            #endregion

            #region New Version
            string path = fj.dirpathDictionaryT1 + "\\" + dictionary + ".json";
            if (File.ReadAllText(path) == "")
                t = new List<MyDictionary>();
            else
            {
                t = fj.ReadObj(t, path).ToList();
            }
            #endregion
        } //Complete
        #endregion
    }
}