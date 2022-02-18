using System;

namespace TicTacToe
{
    static class Program
    {
        public static char[] Board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        public static char[] Pieces = { 'X', 'O' };
        public static int Turn = 0;
        static void Main(string[] args)
        {
            string inp = "n";
            do
            {
                inp = "n";
                Reset();
                Front.Display.StartTurn();
                Console.WriteLine("Wil je nog een potje spelen? (y | n)");
                inp = Console.ReadLine();
            } while (inp.ToLower() != "n");
        }
        public static void Reset()
        {
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = ' ';
            }
            Turn = 0;
        }
    }
}
