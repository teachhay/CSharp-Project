using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WriteFile
{
    public class Write2File
    {
        List<Employee> e = new List<Employee>();
        static private string userName = Environment.UserName;
        private string path = String.Format(@"C:\Users\{0}\Desktop\data.json", userName);
        public void WriteJson()
        {
            var k = JsonConvert.SerializeObject(e);
            File.WriteAllText(path, k);
        }
        public void ReadJson()
        {
            string jsonData = File.ReadAllText(path);
            List<Employee> s = JsonConvert.DeserializeObject<List<Employee>>(jsonData);

            foreach (var i in s)
            {
                Console.WriteLine("Name : {0}, Salary : {1}", i.name, i.salary);
            }
        }
        public void WriteXML()
        {
            e.Add(new Employee("A", 100));
            e.Add(new Employee("B", 200));

            XmlSerializer xml = new XmlSerializer(typeof(List<Employee>));
            TextWriter writer = new StreamWriter("listStudent.xml");
            xml.Serialize(writer, e);
            writer.Close();
        }
        public void ReadXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Employee>));
            TextReader reader = new StreamReader("listStudent.xml");
            List<Employee> temp = (List<Employee>)xml.Deserialize(reader);

            foreach (var i in temp)
            {
                Console.WriteLine("Name : {0}, Salary : {1}", i.name, i.salary);
            }
        }
    }
}
