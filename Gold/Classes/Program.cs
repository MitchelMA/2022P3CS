using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RekenMachine.Add(2, 3));
            Console.WriteLine(RekenMachine.Div(12, 6));
            Console.WriteLine(RekenMachine.Mult(2, 5));
        }
    }

    static class RekenMachine
    {
        public static double Add(double inp1, double inp2)
        {
            return inp1 + inp2;
        }
        public static double Div(double inp1, double inp2)
        {
            return inp1 / inp2;
        }
        public static double Mult(double inp1, double inp2)
        {
            return inp1 * inp2;
        }
    }
}
