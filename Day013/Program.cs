using System;
using System.Collections.Generic;

namespace Day013
{
    class Program
    {
        static string str;

        static int n;

        static HashSet<char> s = new HashSet<char>();

        static void Main(string[] args)
        {
            str = args[0];
            n = Int32.Parse(args[1]);

            int first = 0;
            int last = 1;
            s.Add(str[0]);

            int max = 0;
            string longest = "";

            while(last < str.Length)
            {
                s.Add(str[last]);
                last++;
                while (s.Count > n)
                {
                    s.Remove(str[first]);
                    first++;
                }
                var len = last - first;
                if (len > max)
                {
                    max = len;
                    longest = str.Substring(first, len);
                }
            }

            System.Console.WriteLine(longest);
        }
    }
}
