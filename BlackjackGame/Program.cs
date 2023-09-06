using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BlackjackGame
{
    internal class Program
    {
        static int playerTotalScore = 0;
        static int dealerTotalScore = 0;
        static string playerRole = "player";
        static string playerExpertise = "beginner";
        static int totalGamesPlayed = 0;
        static double playerMoney = 0;

        
        static void Main(string[] args)
        {
            const double initialMoney = 100.00;
            playerMoney = initialMoney;
            int playerTotalCardScore = 0;
            int dealerTotalCardScore = 0;

            PrintIntro();
            Thread.Sleep(1000);
            PrintLogo();
            Thread.Sleep(1000);

            string name = GetPlayerName();
            playerExpertise = GetPlayerExpertise(playerExpertise, totalGamesPlayed);
            string selectedMenuAnswer = PrintMainMenu(playerExpertise, playerMoney, name);

            switch (selectedMenuAnswer)
            {
                case "1":
                    Console.WriteLine($"You selected {selectedMenuAnswer}. Let's start a new game, shall we?!");
                    ShuffleAndDeal();
                    var randomGenerator = new Random();
                    var firstCardScore = HitCard();
                    var secondCardScore = randomGenerator.Next(1, 10);
                    var thirdCardScore = 0;
                    var totalCardScore = firstCardScore + secondCardScore;
                    Thread.Sleep(3000);

                    Console.WriteLine($"Your first card score is: {firstCardScore}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Your second card score is: {secondCardScore}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Your total card score is: {totalCardScore}");
                    Thread.Sleep(3000);
                    Console.WriteLine("Would you like another card?\n1. Yes\n2. No");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string shouldDeal = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (shouldDeal == "1")
                    {
                        thirdCardScore = randomGenerator.Next(1, 10);
                        Console.WriteLine($"Your third card score is: {thirdCardScore}");
                    }

                    totalCardScore += thirdCardScore;

                    Console.WriteLine($"Total card score: {totalCardScore}");

                    if (totalCardScore > 21)
                    {
                        totalGamesPlayed++;
                        Console.WriteLine("BUSTED! Game over. You lose.\nPress any key to quit, loser.");
                        Console.ReadKey();
                        return;
                    }

                    int dealerHand = randomGenerator.Next(3, 21);
                    Console.WriteLine($"The dealer's score is {dealerHand}");
                    Thread.Sleep(2000);

                    if (totalCardScore <= dealerHand)
                    {
                        Console.WriteLine("The dealer's score was higher. Game over. You lose.\nPress any key to quit.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        totalGamesPlayed++;
                        Console.WriteLine("Congratulations! You won!");
                        Console.ReadKey();
                        return;
                    }
                case "2":
                    Console.WriteLine("Are you sure you want to reset stats?\n1. Yes \n2. No");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string promptAnswer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (promptAnswer == "1")
                    {
                        ResetStats(initialMoney, out playerMoney, out totalGamesPlayed);
                    }
                    break;
                case "3":
                    PrintStats(playerMoney, playerRole, playerExpertise, name);
                    return;
                case "4":
                    PrintCredits();
                    return;
                case "5":
                    Console.WriteLine("Exiting Blackjack Game");
                    return;
            }


            Console.ReadKey();


        }

        private static int HitCard(string playerRole = "player")
        {
            var randomGenerator = new Random();
            var cardScore = randomGenerator.Next(1, 10);

            if (playerRole == "player")
            {
                playerTotalScore += cardScore;
            }
            if (playerRole == "dealer")
            {
                dealerTotalScore += cardScore;
            }
            return cardScore;
        }














        private static void PrintIntro()
        {
            Console.Title = "Blackjack Game";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Blackjack The Game");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Creator: Emily SP Bates");
        }
        private static void PrintLogo()
        {
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   *---------------* ");
            Console.WriteLine("  /---------------/| ");
            Console.WriteLine(" /---------------/|| ");
            Console.WriteLine("*                ||| ");
            Console.WriteLine("|   BLACKJACK    ||| ");
            Console.WriteLine("|                ||| ");
            Console.WriteLine("|   THE  GAME    ||| ");
            Console.WriteLine("|                ||| ");
            Console.WriteLine("|                ||| ");
            Console.WriteLine("|   by           ||| ");
            Console.WriteLine("|    Emily Bates ||/ ");
            Console.WriteLine("|                |/  ");
            Console.WriteLine("*---------------*    ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
        }
        private static string GetPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please enter your name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Hello, {name}! Thanks for joining our game.");
            return name;
        }
        private static string GetPlayerExpertise(string playerExpertise, int totalGamesPlayed)
        {
            Console.WriteLine("How many games of Blackjack have you played so far? Please enter an integer.");
            Console.ForegroundColor = ConsoleColor.Green;
            totalGamesPlayed = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Gray;
            if (totalGamesPlayed > 20)
            {
                if (totalGamesPlayed <= 100)
                {
                    playerExpertise = "intermediate";
                }
                else if (totalGamesPlayed <= 150)
                {
                    playerExpertise = "advanced";
                }
                else if (totalGamesPlayed > 150)
                {
                    playerExpertise = "expert";
                }
            }
            else
            {
                playerExpertise = "beginner";
            }
            Console.WriteLine("Great! You'll be considered {0} level player.", playerExpertise);

            return playerExpertise;
        }
        private static string PrintMainMenu(string playerExpertise, double playerMoney, string name)
        {
            Console.WriteLine("You have ${1}. Use it wisely! ;)", playerExpertise, playerMoney);
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Reset Stats");
            Console.WriteLine("3. Stats");
            Console.WriteLine("4. Credits");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\nPlease type your menu selection and press <Enter>");
            Console.ForegroundColor = ConsoleColor.Green;
            string selectedMenuAnswer = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            return selectedMenuAnswer;
        }

        private static void ShuffleAndDeal()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Shuffling the deck...");
            Thread.Sleep(2000);
            Console.WriteLine("Done shuffling the deck.");
            Thread.Sleep(2000);
            Console.WriteLine("Dealing the cards.");
            Thread.Sleep(1000);
            Console.WriteLine("");
        }
        private static void ResetStats(double initialMoney, out double playerMoney, out int totalGamesPlayed)
        {
            totalGamesPlayed = 0;
            playerMoney = initialMoney;
            Console.WriteLine("Stats were reset");
        }
        private static void PrintStats(double playerMoney, string playerRole, string playerExpertise, string name)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Player name: {name}");
            Console.WriteLine($"Player role: {playerRole}");
            Console.WriteLine($"Skill level: {playerExpertise}");
            Console.WriteLine($"Available Funds: ${playerMoney}");
            Console.WriteLine("----------------------------------");
        }
        private static void PrintCredits()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Developer: Edvinas (YT @DeveloperJourney)");
            Console.WriteLine("-----------------------------------------");
        }
    }

}
