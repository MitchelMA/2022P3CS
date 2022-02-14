using System;

namespace Functies
{
    class Program
    {
        public static string Reverse(string s)
        {
            if (s == null)
                return null;

            char[] ch = s.ToCharArray();
            Array.Reverse(ch);
            return new string(ch);
        }
        static void Main(string[] args)
        {
            // declare en initialize de text
            string Hello = "Hello World!";

            // keer de tekst om
            string omg = Reverse(Hello);

            Console.WriteLine(omg);
        }
    }
}
