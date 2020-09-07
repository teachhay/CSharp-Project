using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FluentAssertions.Formatting;

namespace Test
{
    class Test
    {
        private int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int[] index = new int[10];
        private int[] newNum = new int[10];
        private List<string> word = new List<string>();
        static private string userName = Environment.UserName;
        private string path = String.Format(@"C:\Users\{0}\Desktop\Json.txt", userName);
        Stream stream;
        IFormatter formatter;
        List<string> lname = new List<string>();
        public string path2 = @"C:\Users\teach\Desktop\Lesson 14\data.json";
        Employee t = new Employee();
        List<Employee> t2 = new List<Employee>();

        public void Temp()
        {
            string temp;
            int choice = 0;
            word.Add("A");
            word.Add("B");
            word.Add("C");
            word.Add("D");
            word.Add("E"); 

            for (int i = 0; i < word.Count; i++)
            {
                Console.WriteLine("{0} - Score : {1}", i + 1, word[i]);
            }

            choice = int.Parse(Console.ReadLine());

            for (int i = 0; i < word.Count; i++)
            {
                if (choice - 1 == i)
                {
                    Console.WriteLine("Word : {0}", word[i]);
                }
            }
        }
        public void RandomAI()
        {
            Random random = new Random();
            index = Enumerable.Range(0, index.Length).OrderBy(x => random.Next()).Take(index.Length).ToArray();

            for (int i = 0; i < num.Length; i++)
            {
                int temp = index[i];
                newNum[i] = num[temp];
            }
        }
        public void Show()
        {
            foreach (var item in newNum)
            {
                Console.WriteLine(item);
            }
        }
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return objectOut;
        }
        public void JSON(Employee t)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, t);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }
        }
        public void XMLOut(Employee obj)
        {
            formatter = new BinaryFormatter();
            stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, obj);
            stream.Close();
        }
        public void XMLIN()
        {
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            Employee objnew = (Employee)formatter.Deserialize(stream);

            Console.WriteLine(objnew.name);
            Console.WriteLine(objnew.salary);
        }

        public void WriteObj()
        {
            t2.Add(new Employee("T2 - 1", 10));
            t2.Add(new Employee("T2 - 2", 10));

            var k = JsonConvert.SerializeObject(t2);
            File.WriteAllText(path, k);
        }
        public void ReadObj()
        {
            string jsonData = File.ReadAllText(path);
            List<Employee> s = JsonConvert.DeserializeObject<List<Employee>>(jsonData);

            foreach (var i in s)
            {
                Console.WriteLine("Name : {0}, Salary : {1}", i.name, i.salary);
            }
        }
    }
}