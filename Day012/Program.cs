using System;
using System.Collections.Generic;
using System.Linq;

namespace Day012
{
    class Program
    {

        static List<int> steps = new List<int>(); 

        static int total;

        static void Main(string[] args)
        {
            for (var i = 1; i < args.Length; i++)
            {
                steps.Add(Int32.Parse(args[i]));
            }
            total = Int32.Parse(args[0]);
            var results = FindSteps(total, steps);
            // System.Console.WriteLine(results.Count);
            foreach (var result in results)
            {
                string s = "";
                foreach(var n in result)
                {
                    s += $"{n} ";
                }
                System.Console.WriteLine(s);
            }
        }

        static List<List<int>> FindSteps(int total, List<int> steps)
        {
            List<List<int>> nexts = new List<List<int>>(); 
            foreach (var step in steps)
            {
                if (total > step)
                {
                    if(total - step >= steps.Min())
                    {
                        var founds = FindSteps(total - step, steps);
                        foreach (var next in founds)
                        {
                            next.Insert(0, step);
                        }
                        nexts.AddRange(founds);
                    }
                    
                }
                else if (total == step)
                {
                    var next = new List<int>(); 
                    next.Add(step);
                    nexts.Add(next);
                }
                
            }
            return nexts;
        }
    }
}
