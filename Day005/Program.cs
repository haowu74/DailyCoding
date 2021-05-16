using System;
using System.Collections.Generic;

namespace Day005
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var car = program.Car(program.Cons(13,4));
            var cdr = program.Cdr(program.Cons(13,4));
            Console.WriteLine($"{car.ToString()}-{cdr.ToString()}");
        }

        Func<Func<int, int, int>, int> Cons(int a, int b)
        {
            Func<Func<int, int, int>, int> Pair = (f) => 
            {
                return f(a, b);
            };
            return Pair;
        }

        int Car(Func<Func<int, int, int>, int> p)
        {
            return p((a, b) => a);
        }

        int Cdr(Func<Func<int, int, int>, int> p)
        {
            return p((a, b) => b);
        }
    }
}
