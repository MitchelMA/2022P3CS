using System;

namespace TicTacToe.Back
{
    public static class InputHandler
    {
        public static void HandleInput(ConsoleKeyInfo input)
        {
            // account for offset: ('1' -> 49)
            int intInput = (int)input.KeyChar - 48;

            // make sure the input is between 1 and 9
            if ((intInput < 1 || intInput > 9))
            {
                Console.WriteLine();
                Console.WriteLine($"{intInput} is geen geldige plaats. Voer een nieuwe plek tussen 1 en 9 in:");
                HandleInput(Console.ReadKey());

                return;
            }
            if (Program.Board[intInput - 1] != ' ')
            {
                Console.WriteLine();
                Console.WriteLine($"{intInput} is al bezet door {Program.Board[intInput - 1]}.\nVoer een andere plek in (1 - 9):");
                HandleInput(Console.ReadKey());

                return;
            }
        }
    }
}