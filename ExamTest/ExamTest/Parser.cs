using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest
{
    public class Parser
    {
        public string path;

        public char[] array;

        public Dictionary<string, int> words;

        char[] delims = { '\n', '\r', '.', ',', ' ', '!', '?', ';', ':' };

        int countLength = 0;

        public string[] txt;

        public int Exception = 0;

        public Parser(string path)
        {
            this.path = path;
        }

        public void Load()
        {


            FileInfo info = new FileInfo(path);

            if(info.Extension != ".txt")
            {
                Exception = -1;
                return;
            }

            this.countLength = 0;

            countLength = Convert.ToInt32(info.Length);

            array = new char[countLength];

            FileStream stream = new FileStream(info.FullName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            reader.ReadBlock(array, 0, countLength);

            stream.Close();
            reader.Close();


        }

        public void Parse()
        {
            bool isWord = false;
            char[] arr;
            int arr_length;
            int currentI;
            int defis = (int)'-';
            int low = (int)'[';
            int high = (int)'[';
            int appost = (int)'`';

            words = new Dictionary<string, int>();

            txt = (new string(array)).Split(delims, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in txt)
            {
                if (s[0] == '-' || s[s.Length - 1] == '-')
                    continue;
                else
                {
                    isWord = true;
                    arr = s.ToCharArray();
                    arr_length = arr.Length;
                    for (int i = 0; i < arr_length; i++)
                    {
                        currentI = (int)arr[i];

                        if(currentI >= low && currentI <= high)
                        {
                            isWord = false;
                            break;
                        }


                        if ((currentI < 65 || currentI > 122) && currentI != defis && currentI != appost)
                        {
                            isWord = false;
                            break;
                        }

                    }

                    if (isWord == true)
                    {
                        if (words.ContainsKey(s))
                            words[s]++;
                        else
                            words.Add(s, 1);
                    }
                }


            }

        }


        public void start()
        {

            Load();

            if (Exception < 0)
                return;

            Parse();

        }

        public void show()
        {
            foreach(KeyValuePair<string,int> pair in words)
            {
                Console.WriteLine(pair.Key + "   =" + pair.Value.ToString() );
            }
            


        }
    }
}
