using System;

namespace Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Geef een getal (0 of 1): ");
                string inp = Console.ReadLine();

                int parsed;
                try
                {
                    parsed = int.Parse(inp); // correction voor getallen
                    switch (parsed)
                    {
                        case 0:
                            Console.WriteLine("Hallo, dit is case 0");
                            break;
                        case 1:
                            Console.WriteLine("Hallo, dit is case 1");
                            break;
                        default:
                            Console.WriteLine("Dit is de default case");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Dit is geen geldige invoer, voer opnieuw een getal in");
                }

            }
        }

    }
}
