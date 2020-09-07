using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obj2File
{
    [Serializable]
    class Employee
    {
        public string name;
        public int salary;

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