namespace Exam
{
    class Program
    {
        #region Old Version
        //static public void goback(ref int choice)
        //{
        //    Console.WriteLine("\nPress 0 to go back");
        //    Console.WriteLine("Press 9 to exit");
        //    Console.Write("Enter Choice : ");
        //    choice = int.Parse(Console.ReadLine());
        //}
        //static public void stop()
        //{
        //    Console.Clear();
        //    Console.WriteLine("System Shutdown");
        //    System.Threading.Thread.Sleep(1000);
        //    Environment.Exit(0);
        //}
        //static public void Menu()
        //{
        //    Console.Clear();
        //    Console.WriteLine("1. Create new Dictionary");
        //    Console.WriteLine("2. Select Dictionary");
        //    Console.WriteLine("0. Exit");

        //}
        #endregion
        static void Main(string[] args)
        {
            #region Old Version
            //    int choice = 0;
            //    string user;
            //    Dictionary<string, Management> d = new Dictionary<string, Management>();
            //    Management m = new Management();
            //    Management m2;

            //    d.Add("English", m);

            //Mark:
            //    Menu(ref choice);

            //    switch (choice)
            //    {
            //        case 1: //New Dictionary
            //            #region New Dictionary
            //            Console.Clear();

            //            Console.Write("Enter New Dictionary Language : ");
            //            user = Console.ReadLine();

            //            m2 = new Management(user);

            //            d.Add(user, m2);

            //            Console.WriteLine("Sucess");
            //            System.Threading.Thread.Sleep(2000);

            //            goto Mark;
            //        #endregion
            //        case 2: //Select Dictionary
            //            #region Select Dictionary
            //            Console.Clear();

            //            foreach (var i in d)
            //            {
            //                Console.WriteLine("Dictionary Type : {0}", i.Key);
            //            }

            //            Console.Write("Enter Dictionary Type : ");
            //            user = Console.ReadLine();

            //            bool sdsdd = false;

            //            foreach (var i in d)
            //            {
            //                if (user == i.Key.ToLower())
            //                {
            //                    Console.Clear();
            //                    m.Get(i.Key);
            //                    m.Main();
            //                    sdsdd = true;
            //                    break;
            //                }
            //            }
            //            if (!sdsdd)
            //            {
            //                Console.Clear();
            //                Console.WriteLine("Wrong Selected " + user);
            //                System.Threading.Thread.Sleep(2000);
            //                goto Mark;
            //            }

            //            break;
            //        case 0: //Exit
            //            Console.Clear();

            //            stop();

            //            break;
            //            #endregion
            //    }
            #endregion

            #region New Version
            SelectDictionary sd = new SelectDictionary();

            sd.Run();
            #endregion
        }
    }
}