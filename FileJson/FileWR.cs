using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FileJson
{
    public class FileWR
    {
        static private string userName = Environment.UserName;

        #region Task 1 Fields
        public string dirpathT1 = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 1", userName);
        public string dirpathDictionaryT1 = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 1\Dictionary", userName);
        public string dirpathExportT1 = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 1\Export", userName);
        public string pathDictionary = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 1\Dictionary\Backup.json", userName);
        #endregion

        #region Task 2 Fields
        public string dir = String.Format(@"C:\Users\{0}\Desktop\Exam", userName);
        public string dirpath = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2", userName);
        public string dirQuiz = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Quiz", userName);
        public string dirAcc = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Account", userName);
        public string pathQuiz = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Quiz\Quiz.json", userName);
        public string pathAcc = String.Format(@"C:\Users\{0}\Desktop\Exam\Task 2\Account\Account.json", userName);
        #endregion

        #region Methods
        public void WriteObj<T>(List<T> t, string tpath)
        {
            var k = JsonConvert.SerializeObject(t);
            File.WriteAllText(tpath, k);
        }
        public void WriteFile<T>(T t, string tpath)
        {
            var k = JsonConvert.SerializeObject(t);
            File.WriteAllText(tpath, k);
        }
        public List<T> ReadObj<T>(List<T> t, string tpath)
        {
            string jsonData = File.ReadAllText(tpath);
            List<T> s = JsonConvert.DeserializeObject<List<T>>(jsonData);

            return s;
        }
        public T ReadObj<T>(T t, string tpath)
        {
            string jsonData = File.ReadAllText(tpath);
            T s = JsonConvert.DeserializeObject<T>(jsonData);

            return s;
        }
        #endregion

        #region Constructor
        public FileWR()
        {
            #region Task 1 Constructor
            #region Create Folder
            if (!Directory.Exists(dirpathT1) && !Directory.Exists(dirpathDictionaryT1) && !Directory.Exists(dirpathExportT1))
            {
                Directory.CreateDirectory(dirpathT1);
                Directory.CreateDirectory(dirpathDictionaryT1);
                Directory.CreateDirectory(dirpathExportT1);
            }
            #endregion
            #endregion

            #region Task 2 Constructor
            #region Create Folder
            if (!Directory.Exists(dirpath) && !Directory.Exists(dirQuiz) && !Directory.Exists(dirAcc))
            {
                Directory.CreateDirectory(dirpath);
                Directory.CreateDirectory(dirQuiz);
                Directory.CreateDirectory(dirAcc);
            }
            #endregion

            #region Create Files
            if (!File.Exists(pathAcc) && !File.Exists(pathQuiz))
            {
                File.WriteAllText(pathAcc, "");
                File.WriteAllText(pathQuiz, "");
            }
            #endregion
            #endregion
        }
        #endregion
    }
}