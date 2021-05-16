using System;
using System.Collections.Generic;

namespace Day001
{
    class Program
    {
        HashSet<int> Numbers = new HashSet<int>();
        int Sum;

        static void Main(string[] args)
        {
            if (args.Length < 2) 
            {
                System.Console.WriteLine("Too few parameters!");
                return;
            }
            Program program = new Program();
            program.PreProcess(args[0], args[1]);
            string result = program.FindSolution() ? "true" : "false";
            System.Console.WriteLine(result);
        }

        void PreProcess(string numbers, string sum)
        {
            foreach (string n in numbers.Split(','))
            {
                this.Numbers.Add(Int32.Parse(n));
            }
            this.Sum = Int32.Parse(sum);
        }

        bool FindSolution()
        {
            foreach(var n in this.Numbers)
            {
                if (this.Numbers.Contains(this.Sum - n))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
