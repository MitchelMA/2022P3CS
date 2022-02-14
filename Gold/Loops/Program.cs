using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 2, 4, 6, 8, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr.GetValue(i));
            }
        }
    }
}
