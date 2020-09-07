using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            //Test t = new Test();
            //Employee[] e = { 
            //    new Employee("Techhay", 1000), 
            //    new Employee("Keen", 1000), 
            //};

            //Employee e1 = new Employee("Kayla", 100);

            //List<Employee> e2 = new List<Employee>();

            //e2.Add(new Employee("Teachhay", 1));
            //e2.Add(new Employee("Keen", 1));
            //#region Test
            //int choice = 0;
            //bool restart = true;
            //choice = int.Parse(Console.ReadLine());

            //while (restart != false)
            //{
            //    if (choice == 1)
            //    {
            //        Console.WriteLine();
            //        t.RandomAI();
            //        t.Show();

            //        Console.WriteLine();
            //        choice = int.Parse(Console.ReadLine());
            //    }
            //}

            //t.Temp();
            #endregion

            #region Test V2
            //List<int> listNumbers = new List<int>();
            //var rand = new Random();
            //int number;
            //bool restart = true;

            //while (restart != false)
            //{
            //    number = rand.Next(1, 37);
            //    if (!listNumbers.Contains(number))
            //    {
            //        listNumbers.Add(number);
            //    }
            //    else if (listNumbers.Count == 36)
            //    {
            //        restart = false;
            //    }
            //}

            //for (int i = 0; i < listNumbers.Count; i++)
            //{
            //    Console.WriteLine(listNumbers[i]);
            //}

            //Console.WriteLine();
            //Console.WriteLine(listNumbers.Count);
            #endregion

            #region Obj2File
            //t.SerializeObject(e2, "Temp");
            #endregion

            #region Obj2File V2

            #endregion

            #region Obj2File V3
            Test t = new Test();
            Employee e = new Employee();

            //t.WriteObj();
            t.ReadObj();
            #endregion
        }
    }
}
