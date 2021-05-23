using System;
using System.Linq;
using System.Collections.Generic;

namespace Day018
{
    class Program
    {
        static int[] inputs = {10, 5, 2, 7, 8, 7};
        static int k = 3;
        static void Main(string[] args)
        {
            var minSets = new HashSet<int>(k-1);
            for (var i = 0; i < inputs.Length; i++)
            {
                if(minSets.Count() < k - 1)
                {
                    minSets.Add(inputs[i]);
                    inputs[i] = -99999;
                }
                else
                {
                    var max = minSets.Max();
                    if (inputs[i] < max)
                    {
                        minSets.Remove(max);
                        minSets.Add(inputs[i]);
                        inputs[i] = max;
                    }
                }
            }

            foreach (var n in inputs)
            {
                if (n != -99999)
                {
                    System.Console.WriteLine(n);
                }
            }
        }
    }
}
