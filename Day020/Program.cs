using System;

namespace Day020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] linkA = {3, 7, 16, 9, 1, 8, 10};
            int[] linkB = {99, 1, 8, 10};
            var commonLen = linkA.Length > linkB.Length ? linkB.Length : linkA.Length;
            for (var i = 0; i < commonLen; i++)
            {
                if(linkA[linkA.Length - commonLen + i] == linkB[linkB.Length - commonLen + i])
                {
                    System.Console.WriteLine(linkA[linkA.Length - commonLen + i]);
                }
            }
        }
    }
}
