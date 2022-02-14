using System;

namespace Function_Return
{
    class Program
    {
        public static int retRand()
        {
            return (1 + new Random(DateTime.Now.Millisecond).Next(19));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(retRand());
        }
    }
}
