using System;

namespace Day007
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                System.Console.WriteLine("Too few parameters!");
            }
            int result = WaysOfDecoding(args[0]);
            
            System.Console.WriteLine(result);
        }

        static int WaysOfDecoding(string s)
        {
            string s0 = s.Substring(0, 1);
            int n1, n2;
            if(Int32.Parse(s0) != 0)
            {
                n1 = 1;
            }
            else
            {
                n1 = 0;
            }
            if(s.Length == 1)
            {
                return n1;
            }
            string s2 = s.Substring(0, 2);
            if(Int32.Parse(s2) <= 26 && Int32.Parse(s2) >= 10)
            {
                n2 = 1;
            }
            else
            {
                n2 = 0;
            }
            if(s.Length == 2)
            {
                int n = Int32.Parse(s2);
                if(n <= 26 && n > 10 && n != 20)
                {
                    return 2;
                }
                else if(n == 10 || n == 20)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            string s1 = s.Substring(1);
            string s3 = s.Substring(2);

            return n1 * WaysOfDecoding(s1) + n2 * WaysOfDecoding(s3);
        }
    }
}
