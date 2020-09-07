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

namespace Obj2File
{
    class Wrtie
    {
        string userName = Environment.UserName;
        string path = String.Format(@"C:\Users\{0}\Desktop\Json.txt", userName);


        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

        Formatter.Serialize(stream, obj);
            stream.Close();

            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        Tutorial objnew = (Tutorial)formatter.Deserialize(stream);

        Console.WriteLine(objnew.ID);
            Console.WriteLine(objnew.Name);

            Console.ReadKey();
    }
}
