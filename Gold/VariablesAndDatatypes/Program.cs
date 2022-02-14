using System;

namespace VariablesAndDatatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = 1;
            float floatingpoint = integer;
            Console.WriteLine($"{integer}, {floatingpoint}");

            int integer2 = 75;
            char karakter = (char)integer2;
            // Karakter is de letter "K", dit komt omdat char types op de computer als 2 bytes integers worden opgebergd.
            // De overeenkomende code voor "K" (hoofdletter) is toevallig 75
            Console.WriteLine($"{integer2}, {karakter}");
        }
    }
}
