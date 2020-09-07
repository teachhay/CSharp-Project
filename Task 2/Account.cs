using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileJson;

namespace Task_2
{
    class Account
    {
        #region Fields
        private static int i = 0;
        public int id;
        public string fname;
        public string lname;
        public int day;
        public int month;
        public int year;
        public string address;
        public string password;
        public List<int> score = new List<int>();
        private List<Account> a = new List<Account>();
        private FileWR fj = new FileWR();
        #endregion

        #region Methods
        public int Score()
        {
            return score.LastOrDefault();
        } //Complete
        public void ShowScore()
        {
            int j = 0;
            if (score.Count < 1)
            {
                Console.WriteLine("User doesn't have previous scores");
            }
            else
            {
                foreach (var i in score)
                {
                    j++;
                    Console.WriteLine("Score {0} : {1} | 100", j, i);
                }
            }
        } //Complete
        #endregion

        #region Constructor
        public Account()
        {

        } //Complete
        public Account(string _fname, string _lname, int _day, int _month, int _year, string _address, string _password)
        {
            if (File.ReadAllText(fj.pathAcc) == "")
            {
                i++;
                this.id = i;
                this.fname = _fname;
                this.lname = _lname;
                this.day = _day;
                this.month = _month;
                this.year = _year;
                this.address = _address;
                this.password = _password;
            }
            else
            {
                a = fj.ReadObj(a, fj.pathAcc).ToList();

                this.id = a.Count + 1;
                this.fname = _fname;
                this.lname = _lname;
                this.day = _day;
                this.month = _month;
                this.year = _year;
                this.address = _address;
                this.password = _password;
            }
        } //Complete
        #endregion
    }
}