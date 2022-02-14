using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // console kleur
            Console.ForegroundColor = ConsoleColor.Green;

            // tekst om uit te printen
            string Hello = "Hello World!";

            foreach (char ch in Hello)
            {
                Console.Write(ch);
                Thread.Sleep(1000);
            }
        }
    }
}
