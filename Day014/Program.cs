using System;

namespace Day014
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            double inside = 0.0;
            double outside = 0.0;
            for (var i = 0; i < 100000000; i++)
            {
                var x = rand.NextDouble() * 2 - 1;
                var y = rand.NextDouble() * 2 - 1;
                if (x * x + y * y <= 1)
                {
                    inside ++;
                }
                else
                {
                    outside ++;
                }
            }
            System.Console.WriteLine(inside / (inside + outside) * 4.0);
        }
    }
}
