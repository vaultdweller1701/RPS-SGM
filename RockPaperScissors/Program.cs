using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        static bool IsComplete = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!");
            Console.WriteLine("\n");

            // Program Loop
            while (!IsComplete)
            {
                Game Game = new Game();
                // Game Loop
                while (!Game.IsComplete)
                {
                    // Do game stuff
                    foreach (Player player in Game.Players)
                    {
                        player.MakeMove(Game.IsExtendedGame);
                    }

                    // Evaluate for victory
                    Game.EvaluateGame();
                    
                }
                // End of game wrap-up

                IsComplete = !Helpers.BinaryChoice("Would you like to play again?");
                Console.Clear();
            }

            Console.WriteLine("Thanks for playing!");
            Thread.Sleep(500);
        }
    }
}
