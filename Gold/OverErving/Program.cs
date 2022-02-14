using System;
// gebruik mijn eigen namespace
using OverErving.Animals;

namespace OverErving
{
    class Program
    {
        static void Main(string[] args)
        {
            Horse myHorse = new Horse();
            myHorse.Feed();
            Console.WriteLine(myHorse.Status());
        }
    }
}
