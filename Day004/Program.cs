using System;
using System.Collections.Generic;

namespace Day004
{
    class Program
    {
        List<int> numbers = new List<int>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PreProcess(args[0]);
            for(int i = 0; i < program.numbers.Count; i++)
            {
                while(i+1 != program.numbers[i] && program.numbers[i] > 0 && program.numbers[i] <= program.numbers.Count)
                {
                    var n = program.numbers[i];
                    var m = program.numbers[i]-1;
                    if(program.numbers[m] == n)
                    {
                        break;
                    }
                    program.numbers[i] = program.numbers[m];
                    program.numbers[m] = n;
                }
            }
            System.Console.WriteLine(program.FindMissingNumber().ToString());
        }

        void PreProcess(string numbers)
        {
            foreach (string n in numbers.Split(','))
            {
                this.numbers.Add(Int32.Parse(n));
            }
        }

        int FindMissingNumber()
        {
            for(int n = 0; n < this.numbers.Count; n++)
            {
                if(this.numbers[n] != n+1)
                {
                    return n+1;
                }
            }
            return this.numbers.Count+1;
        }
    }
}
