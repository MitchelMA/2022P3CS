using System;
// gebruik van eigen namespaces
using TicTacToe.Front;
using TicTacToe.Back;

namespace TicTacToe
{
    static class Program
    {
        public static char[] Board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        public static char[] Pieces = { 'X', 'O' };
        public static int Turn = 0;
        static void Main(string[] args)
        {
            Display.StartTurn();
        }
    }
}
