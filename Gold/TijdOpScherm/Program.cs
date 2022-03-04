using System;
using System.Threading;

namespace TijdOpScherm
{
    class Program
    {
        void SetFore()
        {
            int rand = new Random(DateTime.Now.Millisecond).Next(3);
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue };
            Console.ForegroundColor = colors[rand];
        }
        static void Main(string[] args)
        {
            // functie om de kleur te bepalen

            // loop om te herhalen
            do
            {
                // clear the console
                Console.Clear();

                // zet de tekstkleur
                Program program = new Program();
                program.SetFore();

                // print de tijd uit
                Console.WriteLine(DateTime.Now);

                Thread.Sleep(1000);
            } while (true);
        }
    }
}
