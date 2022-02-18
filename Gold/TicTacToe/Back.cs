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

            // set the players choice on the board
            Program.Board[intInput - 1] = Program.Pieces[Program.Turn % 2];

            // check the board status
            char[] Status = CheckBoard();
            // Convert the output, either 1 or 0 to a boolean
            if (Convert.ToBoolean((int)Status[0]))
            {
                // Once Again, convert an integer to a boolean
                Console.Clear();
                if (Convert.ToBoolean((int)Status[1]))
                    Console.WriteLine($"{Status[1]} is de winnaar!");
                else
                    Console.WriteLine("Er is geen winnaar, het spel is afgelopen");
                Front.Display.Draw();
                return;
            }

            Program.Turn++;
            Front.Display.StartTurn();
        }
        public static char[] CheckBoard()
        {
            // booleans and characters get saved as integers, so I can just just use a char array to
            // both read it as a boolean and a character or number
            char[] Status = {
                (char)0, // gets used as a boolean
                (char)0  // gets used as a character
            };

            string statusString = "";
            // check horizontal
            for (int column = 0; column < 3; ++column)
            {
                statusString += Program.Board[3 * column];
                statusString += Program.Board[3 * column + 1];
                statusString += Program.Board[3 * column + 2];

                if (statusString == "OOO")
                {
                    Status[0] = (char)1;
                    Status[1] = 'O';
                    return Status;
                }
                else if (statusString == "XXX")
                {
                    Status[0] = (char)1;
                    Status[1] = 'X';
                    return Status;
                }
            }

            // check vertical
            statusString = "";
            for (int row = 0; row < 3; ++row)
            {
                statusString += Program.Board[0 + row];
                statusString += Program.Board[3 + row];
                statusString += Program.Board[6 + row];

                if (statusString == "OOO")
                {
                    Status[0] = (char)1;
                    Status[1] = 'O';
                    return Status;
                }
                else if (statusString == "XXX")
                {
                    Status[0] = (char)1;
                    Status[1] = 'X';
                }
            }

            // check diagonal (top-left to bottom-right)
            if (Program.Board[0] == Program.Board[4] && Program.Board[0] == Program.Board[8] && (Program.Board[0] != ' '))
            {
                Status[0] = (char)1;
                Status[1] = Program.Board[0];
                return Status;
            }

            // check diagonal (top-right to bottom-left)
            if (Program.Board[2] == Program.Board[4] && Program.Board[2] == Program.Board[6] && (Program.Board[2] != ' '))
            {
                Status[0] = (char)1;
                Status[1] = Program.Board[2];
                return Status;
            }

            // check if the board is filled
            int isFilled = Array.IndexOf(Program.Board, ' ');

            if (isFilled == -1)
            {
                Status[0] = (char)1;
                Status[1] = (char)0;
                return Status;
            }



            return Status;
        }
    }
}