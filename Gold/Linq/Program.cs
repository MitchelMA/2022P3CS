using System;
// use the generic collection
using System.Collections.Generic;
// use the linq namespace
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // create enumerable integer array
            int[] myArray = { 10, 40, 33, 80, 91, 100, 50, 81, 67, 83 };

            // define a query expression
            IEnumerable<int> query =
                from integer in myArray
                where integer > 70
                select integer;

            // execute the query
            foreach (int i in query)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // string length
            string[] array = { "Dit is kort", "Dit is veel langer dan de vorige", "Bij deze is het de bedoeling dat het nog veel langer zal zijn", "kortst" };
            IEnumerable<string> queryS =
                from S in array
                where S.Length > 30
                select S;
            IEnumerable<string> queryS2 =
                from S in array
                where S.Length < 30
                select S;

            foreach (string s in queryS)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            foreach (string s in queryS2)
            {
                Console.WriteLine(s);
            }
        }
    }
}
