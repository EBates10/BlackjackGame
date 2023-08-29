using System;

namespace BlackjackGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double initialMoney = 100.00;
            double playerMoney = initialMoney;
            string playerRole = "Player";
            string playerExpertise = "Beginner";
            int totalGamesPlayed = 0;

            if (totalGamesPlayed >= 20)
            {
                playerExpertise = "Intermediate";
            } 
            else if (totalGamesPlayed >= 100)
            {
                playerExpertise = "Advanced";
            } else
            {
                playerExpertise = "Beginner";
            }


            Console.Title = "Blackjack Game";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Blackjack The Game");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Creator: Emily SP Bates");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}! Your money count is ${1}.", name, playerMoney);
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Reset Stats");
            Console.WriteLine("\nPlease enter your menu selection and press <Enter>");
            string selectedMenuAnswer = Console.ReadLine();
            Console.WriteLine($"You selected {selectedMenuAnswer}");

            switch(selectedMenuAnswer)
            {
                case "1":
                    Console.WriteLine("Shuffling the deck...");
                    Console.WriteLine("Done shuffling the deck.");
                    Console.WriteLine("Serving the cards.");
                    Console.WriteLine("");
                    var randomGenerator = new Random();
                    var firstCardScore = randomGenerator.Next(1, 10);
                    var secondCardScore = randomGenerator.Next(1, 10);
                    var thirdCardScore = 0;

                    Console.WriteLine($"Your first card score is: {firstCardScore}");
                    Console.WriteLine($"Your second card score is: {secondCardScore}");
                    Console.WriteLine("Would you like another card?\n1. Yes\n2. No");
                    string shouldDeal = Console.ReadLine();
                    if (shouldDeal == "1")
                    {
                        thirdCardScore = randomGenerator.Next(1, 10);
                        Console.WriteLine($"Your third card score is: {thirdCardScore}");
                    }

                    var totalCardScore = firstCardScore + secondCardScore + thirdCardScore;

                    Console.WriteLine($"Total card score: {totalCardScore}");

                    if (totalCardScore > 21)
                    {
                        Console.WriteLine("Game over. You lose.\nPress any key to quit.");
                        Console.ReadKey();
                        return;
                    }

                    int dealerHand = randomGenerator.Next(10, 21);

                    if (totalCardScore <= dealerHand)
                    {
                        Console.WriteLine("Game over. You lose.\nPress any key to quit.");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Congratulations! You won!");
                    Console.ReadKey();
                    return;
                case "2":
                    Console.WriteLine("Are you sure you want to reset stats?\n1. Yes \n2. No");
                    string promptAnswer = Console.ReadLine();
                    if (promptAnswer == "1")
                    {
                        totalGamesPlayed = 0;
                        playerMoney = initialMoney;
                        Console.WriteLine("Stats were reset");
                    }
                    break;
                case "3":
                    Console.WriteLine("Exiting Blackjack Game");
                    return;
            }


            Console.ReadKey();


        }
    }
}
