using System;
using System.Collections.Generic;

namespace Exam
{
    public class MyDictionary
    {
        #region Fields
        public string word, inputdef;
        public List<Definition> def = new List<Definition>();
        private int j = 0;
        #endregion

        #region Methods
        public void AddDef()
        {
            Console.Write("Enter Definition: ");
            inputdef = Console.ReadLine();
            def.Add(new Definition(inputdef));
        } //Complete
        public void ShowDef()
        {
            j = 0;
            foreach (var item in def)
            {
                j++;
                Console.WriteLine("Definition {0} : {1}", j, item.definition);
            }
        } //Complete
        public void EditDef(string word)
        {
            try
            {
                bool check = true;
                for (int i = 0; i < def.Count; i++)
                {
                    Console.WriteLine("{0} - Definition : {1}", i + 1, def[i].definition);
                }

                j = 0;
                Console.Write("Select : ");
                j = int.Parse(Console.ReadLine());

                for (int l = 0; l < def.Count; l++)
                {
                    if (j - 1 == l)
                    {
                        string temp = def[l].definition;
                        check = true;
                        Console.Clear();
                        Console.WriteLine("Current Definition : {0}", temp);
                        Console.Write("Enter New Definition : ");
                        inputdef = Console.ReadLine();
                        def[l].definition = inputdef;
                        Console.Clear();
                        Console.WriteLine("Word {0} definition {1} updated to {2}", word, temp, inputdef);
                        break;
                    }
                    check = false;
                }
                if (check != true)
                {
                    Console.Clear();
                    Console.Write("Please select correct option.");
                    Console.ReadKey();
                    Console.Clear();
                    EditDef(word);
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e.Message);
                Console.ReadKey();
                Console.Clear();
                EditDef(word);
            }
        } //Complete
        public void DeleteDef()
        {
            try
            {
                bool check = true;
                j = 0;

                if (def.Count != 1)
                {
                    for (int i = 0; i < def.Count; i++)
                    {
                        Console.WriteLine("{0} - Definition : {1}", i + 1, def[i].definition);
                    }

                    Console.Write("Select : ");
                    j = int.Parse(Console.ReadLine());

                    for (int l = 0; l < def.Count; l++)
                    {
                        if (j - 1 == l)
                        {
                            check = true;
                            def.RemoveAt(l);
                            Console.Clear();
                            Console.WriteLine("Word {0} definition deleted", word);
                            break;
                        }
                        check = false;
                    }
                    if (check != true)
                    {
                        Console.Clear();
                        Console.Write("Please select correct option.");
                        Console.ReadKey();
                        Console.Clear();
                        DeleteDef();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Cannot Remove selected definition as it is the last");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e.Message);
                Console.ReadKey();
                Console.Clear();
                DeleteDef();
            }
        } //Complete
        #endregion

        #region Constructor
        public MyDictionary() { } //Complete
        public MyDictionary(string _word, string _defination)
        {
            this.word = _word;
            def.Add(new Definition(_defination));
        } //Complete
        #endregion
    }
}