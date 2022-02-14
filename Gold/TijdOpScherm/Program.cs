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
                switch (rand)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                }
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
