using System;
using System.Collections.Generic;
using System.IO;

namespace Day016
{
    class Program
    {
        static string[] ids;

        static int num;

        static int first;

        static int last;

        static void Main(string[] args)
        {
            num = Int32.Parse(args[1]);
            ids = new string[num];
            using (StreamReader sr = new StreamReader(args[0]))
            {
                first = -1;
                last = -1;
                while(sr.Peek() >= 0)
                {
                    var s = sr.ReadLine();
                    Record(s);
                }
            }
            for(int i = 1; i < 10; i++)
            {
                if(i <= num)
                {
                    System.Console.WriteLine(GetLast(i));
                }
            }
        }

        static void Record(string id)
        {
            if(first == -1 && last == -1)
            {
                ids[0] = id;
                first = 0;
                last = 1;
            }
            else
            {
                if ((last - first + num) % num != num - 1)
                {
                    ids[last] = id;
                    last = (last + 1) % num;
                }
                else
                {
                    ids[last] = id;
                    first = (first + 1) % num;
                    last = (last + 1) % num;
                }
            }
        }

        static string GetLast(int n)
        {
            return ids[(last - n + num) % num];
        }
    }
}
