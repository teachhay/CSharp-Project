using System;

namespace Task_2
{
    class Program
    {
        #region Old Verson
        //static public void AdminMenu(ref int choice)
        //{
        //    Console.WriteLine("1. Show All");
        //    Console.WriteLine("2. Add Account");
        //    Console.WriteLine("3. Add Score");
        //    Console.WriteLine("4. Logout");
        //    Console.WriteLine("5. Show Specific Account");
        //    Console.WriteLine("6. Show Specific Account Score");
        //    Console.WriteLine("7. Edit Password | Date of Birth");
        //    Console.WriteLine("8. Quiz Utility");
        //    Console.WriteLine("9. Exit");
        //    Console.Write("Enter Choice: ");
        //    choice = int.Parse(Console.ReadLine());
        //}
        //static public void UserMenu(ref int choice)
        //{
        //    Console.WriteLine("1. Start Quiz");
        //    Console.WriteLine("2. View Previous Quizzes");
        //    Console.WriteLine("3. View Top 20 for Quiz");
        //    Console.WriteLine("4. Change Password | Date of Birth");
        //    Console.WriteLine("5. Logout");
        //    Console.WriteLine("6. Show Profile");
        //    Console.WriteLine("9. Exit");
        //    Console.Write("Enter Choice: ");
        //    choice = int.Parse(Console.ReadLine());
        //}
        //static public void stop()
        //{
        //    Console.Clear();
        //    Console.WriteLine("System Shutdown");
        //    System.Threading.Thread.Sleep(1000);
        //    Environment.Exit(0);
        //}
        //static public void Login(ref int choice)
        //{
        //    Console.WriteLine("1. Login");
        //    Console.WriteLine("2. Create Account");
        //    Console.Write("Enter Choice: ");
        //    choice = int.Parse(Console.ReadLine());
        //}
        //static public void Account(ref string username, ref string password)
        //{
        //    Console.Write("Enter Username: ");
        //    username = Console.ReadLine();
        //    Console.Write("Enter Password: ");
        //    password = Console.ReadLine();

        //    //while (true)
        //    //{
        //    //    ConsoleKeyInfo consoleKey = Console.ReadKey(true);
        //    //    if (consoleKey.Key == ConsoleKey.Enter)
        //    //        break;
        //    //    else if (consoleKey.Key == ConsoleKey.Backspace)
        //    //    {
        //    //        Console.Write("\b \b");
        //    //    }
        //    //    else
        //    //    {
        //    //        Console.Write("*");
        //    //        password += consoleKey.KeyChar;
        //    //    }
        //    //}
        //}
        //static public void goback(ref int choice)
        //{
        //    Console.WriteLine("Press 0 to go back");
        //    Console.WriteLine("Press 9 to exit");
        //    Console.Write("Enter Choice: ");
        //    choice = int.Parse(Console.ReadLine());
        //}
        #endregion
        static void Main(string[] args)
        {
            #region Old Version
            //Management a = new Management();
            //int choice = 0, score;
            //string username = "", password = "", temp, account = "";
            //bool restart = true;

            //#region Login
            //Login:
            //    Login(ref choice);

            //    while (restart != false)
            //    {
            //        switch (choice)
            //        {
            //            case 1: //Login
            //                Console.Clear();
            //                goto Account;
            //            case 2: //Create Account
            //                Console.Clear();

            //                a.Add(ref choice);

            //                if (choice == 0) //Check Account Exist 
            //                {
            //                    Thread.Sleep(1500);
            //                    Console.Clear();
            //                    goto Login;
            //                }
            //                else //Successfully Create Account
            //                {
            //                    Console.WriteLine("Successfully Create Account");
            //                    Thread.Sleep(1500);
            //                    Console.Clear();
            //                    goto Account;
            //                }
            //            case 3:
            //                Console.Clear();
            //                goto Admin;
            //            default:
            //                break;
            //        }
            //    }
            //#endregion

            //#region Account
            //Account:
            //    Account(ref username, ref password);

            //    while (restart != false)
            //    {
            //        if (a.login(username, password) == true) //Successfully Login
            //        {
            //            Console.Clear();
            //            account = username;
            //            goto User;
            //        }
            //        else if (a.checkaccount(username) == true) //Password Failed
            //        {
            //            Console.WriteLine("\nWrong username or password!");
            //            Console.WriteLine("Please try again!");
            //            Thread.Sleep(1500);
            //            Console.Clear();
            //            goto Account;
            //        }
            //        else if (username == "admin" && password == "admin") //Admin Login
            //        {
            //            Console.Clear();
            //            Console.WriteLine("Admin Login");
            //            Thread.Sleep(1500);
            //            Console.Clear();

            //            goto Admin;
            //        }
            //        else //No Existing Account
            //        {
            //            Console.WriteLine("\nNo Account found!");
            //            Thread.Sleep(1500);
            //            Console.Clear();
            //            goto Login;
            //        }
            //    }
            //#endregion

            //#region User
            //User:
            //    UserMenu(ref choice);
            //    while (restart != false)
            //    {
            //        #region Option
            //        switch (choice)
            //        {
            //            case 1: //Start Quiz
            //                a.Uplay(account);

            //                goback(ref choice);
            //                break;
            //            case 2: //View Previous Quizzes
            //                Console.Clear();

            //                a.ShowScore(account);

            //                goback(ref choice);
            //                break;
            //            case 3: //View 20 Quzis

            //                goback(ref choice);
            //                break;
            //            case 4: //Edit Password | Date of Birth
            //                Console.Clear();

            //                a.EditAccount(account);

            //                goback(ref choice);
            //                break;
            //            case 5: // Logout
            //                restart = true;

            //                Console.Clear();

            //                goto Login;
            //            case 6:
            //                Console.Clear();

            //                a.ShowAccount(account);

            //                goback(ref choice);
            //                break;
            //            case 9:
            //                a.SaveAccount(account);
            //                stop();
            //                restart = false;
            //                break;
            //            case 0:
            //                Console.Clear();
            //                goto User;
            //        }
            //        #endregion
            //    }
            //#endregion

            //#region Admin
            //Admin:
            //    AdminMenu(ref choice);
            //    while (restart != false)
            //    {
            //        switch (choice)
            //        {
            //            case 1: //Show All Account
            //                Console.Clear();
            //                a.Show();

            //                goback(ref choice);
            //                break;
            //            case 2: //Add Account
            //                Console.Clear();
            //                a.Add(ref choice);

            //                goback(ref choice);
            //                break;
            //            case 3: //Add Score to Account
            //                Console.Clear();

            //                Console.Write("FName : ");
            //                temp = Console.ReadLine();
            //                Console.Write("Score : ");
            //                score = int.Parse(Console.ReadLine());

            //                a[temp].score.Add(score);
            //                Console.WriteLine();

            //                goback(ref choice);
            //                break;
            //            case 4: // Logout
            //                restart = true;

            //                Console.Clear();

            //                goto Login;
            //            case 5: //Show Specific Account
            //                Console.Clear();

            //                a.ShowAccount(account);

            //                goback(ref choice);
            //                break;
            //            case 6: //Show Specific Accout Score
            //                Console.Clear();

            //                a.ShowScore(account);

            //                goback(ref choice);
            //                break;
            //            case 7: //Edit Password | Date of Birth
            //                Console.Clear();

            //                a.EditAccount(account);

            //                goback(ref choice);
            //                break;
            //            case 8: //Quiz
            //                Console.Clear();
            //                a.Option();

            //                goback(ref choice);
            //                break;
            //            case 9: //Exit
            //                stop();
            //                restart = false;
            //                break;
            //            case 0: //Go back
            //                Console.Clear();
            //                goto Admin;
            //        }
            //    }
            //    #endregion
            #endregion

            #region New Version | Final
            SelectQuiz sq = new SelectQuiz();
            
            sq.Run();
            #endregion
        }
    }
}