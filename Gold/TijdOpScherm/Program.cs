using System;
using System.Threading;

namespace TijdOpScherm
{
    class Program
    {
        static void Main(string[] args)
        {
            // functie om de kleur te bepalen
            void setFore()
            {
                int rand = new Random(DateTime.Now.Millisecond).Next(3);
                ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue };
                Console.ForegroundColor = colors[rand];
            }

            // loop om te herhalen
            do
            {
                // clear the console
                Console.Clear();

                // zet de tekstkleur
                setFore();

                // print de tijd uit
                Console.WriteLine(DateTime.Now);

                Thread.Sleep(1000);
            } while (true);
        }
    }
}
