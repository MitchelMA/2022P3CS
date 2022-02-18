using System;

namespace TicTacToe.Front
{
    public static class Display
    {
        public static void Draw()
        {
            Console.WriteLine($"{Program.Board[0]} | {Program.Board[1]} | {Program.Board[2]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{Program.Board[3]} | {Program.Board[4]} | {Program.Board[5]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{Program.Board[6]} | {Program.Board[7]} | {Program.Board[8]}");
        }

        public static void StartTurn()
        {
            Console.Clear();
            Console.WriteLine($"Beurt: {Program.Turn + 1}");
            Draw();
            Console.WriteLine($"Speler {Program.Pieces[Program.Turn % 2]} is nu aan de beurt");
            Console.WriteLine($"Op welke plek wil je een \"{Program.Pieces[Program.Turn % 2]}\" plaatsen? (1-9)");
            Back.InputHandler.HandleInput(Console.ReadKey());
        }
    }
}