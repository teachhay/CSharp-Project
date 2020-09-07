using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteFile
{
    public class Employee
    {
        public string name;
        public int salary;

        public void Show()
        {
            Console.WriteLine(name);
            Console.WriteLine(salary);
        }

        public Employee()
        {

        }
        public Employee(string _name, int _salary)
        {
            this.name = _name;
            this.salary = _salary;
        }
    }
}
