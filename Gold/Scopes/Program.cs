using System;

namespace Scopes
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 5)
                    {
                        Console.WriteLine("i is 5");
                    }
                }
            }
        }
    }
}
