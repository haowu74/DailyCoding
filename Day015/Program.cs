using System;
using System.IO;

namespace Day015
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            string selectedStr = "";
            var rand = new Random();
            using (StreamReader sr = new StreamReader(args[0]))
            {
                while(sr.Peek() >= 0)
                {
                    var s = sr.ReadLine();
                    var r = rand.Next(0, i);
                    var selected = r == 0;
                    if (selected)
                    {
                        selectedStr = s;
                    }
                    i++;
                }
            }
            System.Console.WriteLine(selectedStr);
        }
    }
}
