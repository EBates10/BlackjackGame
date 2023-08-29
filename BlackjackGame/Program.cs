using System;

namespace BlackjackGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Blackjack Game";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Blackjack The Game");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Creator: Emily SP Bates");

            Console.ReadKey();
        }
    }
}
