using System;
using System.Collections.Generic;

namespace Day009
{
    class Program
    {
        List<int> numbers = new List<int>();
        Dictionary<int, int> cache = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PreProcess(args[0]);
            Console.WriteLine(program.GetMaxSum(0));
        }

        void PreProcess(string numbers)
        {
            foreach (string n in numbers.Split(','))
            {
                this.numbers.Add(Int32.Parse(n));
            }
        }

        int GetMaxSum(int start)
        {
            int max;
            if(this.numbers.Count - start == 1)
            {
                max = this.numbers[start];
            }
            else if (this.numbers.Count -start == 2)
            {
                max = this.numbers[start] >= numbers[start + 1] ? numbers[start] : numbers[start + 1];
            }
            else
            {
                if(!cache.ContainsKey(start+1))
                {
                    cache[start+1] = this.GetMaxSum(start+1);
                }
                if(!cache.ContainsKey(start+2))
                {
                    cache[start+2] = this.GetMaxSum(start+2);
                }
                int option1 = this.numbers[start] + GetMaxSum(start+2);
                int option2 = GetMaxSum(start+1);
                max = option1 >= option2 ? option1 : option2;
            }
            return max;
        }
    }
}
