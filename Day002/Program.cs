using System;
using System.Collections.Generic;

namespace Day002
{
    class Program
    {
        List<int> numbers = new List<int>();
        List<int> prefix = new List<int>();
        List<int> postfix = new List<int>();

        static void Main(string[] args)
        {
            if (args.Length < 1) 
            {
                System.Console.WriteLine("Too few parameters!");
                return;
            }
            Program program = new Program();
            program.PreProcess(args[0]);
            program.BuildHelperLists();
            string result = "";
            program.ProduceSolution().ForEach(n => result += n.ToString() + " ");
            System.Console.WriteLine(result);
        }

        void PreProcess(string numbers)
        {
            foreach (string n in numbers.Split(','))
            {
                this.numbers.Add(Int32.Parse(n));
            }
        }

        void BuildHelperLists()
        {
            for(int n = 0; n < this.numbers.Count; n++)
            {
                if (n == 0)
                {
                    this.prefix.Add(1);
                }
                else
                {
                    this.prefix.Add(this.prefix[this.prefix.Count-1] * this.numbers[n-1]);
                }
            }
            for(int n = this.numbers.Count - 1; n >= 0; n--)
            {
                if (n == this.numbers.Count - 1)
                {
                    this.postfix.Add(1);
                }
                else
                {
                    this.postfix.Add(this.postfix[this.postfix.Count-1] * this.numbers[n+1]);
                }
            }
        }

        List<int> ProduceSolution()
        {
            List<int> result = new List<int>();
            for (int n = 0; n < this.numbers.Count; n++)
            {
                result.Add(this.prefix[n] * this.postfix[this.numbers.Count-1-n]);
            }
            return result;
        }
    }
}
