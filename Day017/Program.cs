using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day017
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = args[0];
            str = str.Replace("\\n", "\n");
            str = str.Replace("\\t", "\t");
            var maxLen = GetMaxLen(str, 1, 0);
            System.Console.WriteLine(maxLen);
        }

        static int GetMaxLen(string str, int layer, int length)
        {
            string pattern1 = "\\t";
            string pattern2 = "(?!\\t)";
            string pattern = "\\n";
            for (var i = 0; i < layer; i++)
            {
                pattern += pattern1;
            }
            pattern += pattern2;
            var strs = Regex.Split(str, pattern);

            if (strs.Count() == 1)
            {
                return length + str.Length;
            }

            var maxLen = 0;
            var len = 0;
            
            for (var i = 1; i < strs.Count(); i++)
            {
                len = GetMaxLen(strs[i], layer+1, strs[0].Length);
                if (len > maxLen)
                {
                    maxLen = len;
                }
            }
            return length + maxLen + 1;
        }

    }
}
