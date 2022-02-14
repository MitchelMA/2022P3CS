using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 10, 20, 30, 40, 50, 60 };
            int[] B = new int[6];
            int it = 0;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                B[it] = A[i];
                it++;
            }
            foreach (int temp in A)
            {
                Console.Write($"{temp} ");
            }
            Console.WriteLine();
            foreach (int temp in B)
            {
                Console.Write($"{temp} ");
            }
        }
    }
}
