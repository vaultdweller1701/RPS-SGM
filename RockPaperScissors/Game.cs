using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors
{
    class Game
    {
        // Properties
        public List<Player> Players { get { return _players; } }
        public bool IsComplete { get { return _isComplete; } set { _isComplete = value; } }
        public bool IsExtendedGame { get { return _isExtendedGame; } }
        public int Turns { get { return _turns; } }


        // Members
        private List<Player> _players;
        private bool _isComplete;
        private bool _isExtendedGame;
        private int _turns;

        private static string[,] _verbs = new string[5, 5]
        {
            {"","","","","crushes" },
            {"vaporises","","","","smashes" },
            {"covers","disproves","","","" },
            {"","poisons","eats","","" },
            {"","","cut","decapitate","" }
        };
        private static string[] _adverbs = new string[16]
        {
            "","violently ","","sneakily ","","","feverently ","","artfully ","","logically ","","quite naturally ","brutally ","",""
        };

        // Methods

        public void EvaluateGame()
        {
            int p1 = (int)Players[0].Moves[0];
            int p2 = (int)Players[1].Moves[0];

            Console.WriteLine($"{Players[0].Name} played {Players[0].Moves[0].ToString()}!");
            Console.WriteLine($"{Players[1].Name} played {Players[1].Moves[0].ToString()}!");

            // Arithmetically calculate winner
            int result = (5 + p1 - p2) % 5;
            //Console.WriteLine(result);
            if (result == 0)
            {
                IsComplete = false;
                Console.WriteLine("It's a draw! Go again!\n");
                _turns++;
            }
            else if (result < 3)
            {
                GameFinished(1, 2, _turns);
            }
            else
            {
                GameFinished(2, 1, _turns);
            }
            //else if (results )
            //switch (result)
            //{
            //    case 0:
            //        IsComplete = false;
            //        Console.WriteLine("It's a draw! Go again!\n");
            //        _turns++;
            //        break;
            //    case 1:
            //        GameFinished(result, _turns);
            //        break;
            //    case 2:
            //        GameFinished(result, _turns);
            //        break;
            //    default:
            //        throw new NotImplementedException();
            //}
        }

        private void GameFinished(int winner, int loser, int turns)
        {
            // Win announcement
            Player winP = Players[winner - 1];
            Player loseP = Players[loser - 1];
            Move winM = winP.Moves[0];
            Move loseM = loseP.Moves[0];
            var temp1 = (int)winM;
            var temp2 = (int)loseM;
            string adverb = _adverbs[new Random().Next(0, 16)];
            Console.WriteLine($"{winP.Name}'s {winM.ToString()} {adverb}{_verbs[(int)winM,(int)loseM]} {loseP.Name}'s {loseM.ToString()}");
            Console.WriteLine($"{Players[winner - 1].Name} won the match!");
            
            // Turn count
            Console.WriteLine($"It took {turns} turn{(turns > 1 ? "s" : "")}.");
            
            // Popular move
            List<Move> allMoves = new List<Move>();
            allMoves.AddRange(Players[0].Moves);
            allMoves.AddRange(Players[1].Moves);

            var query = allMoves.GroupBy(x => x).Select(group => new { Move = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count);
            var item = query.First().Move.ToString() ;

            Console.WriteLine($"The most popular move was {item}.\n");

            // End the game
            IsComplete = true;
        }

        // Constructor
        public Game()
        {
            _turns = 1;
            _isComplete = false;
            _players = new List<Player>();
            _players.Add(new Player("Player 1", false));

            _isExtendedGame = Helpers.BinaryChoice("Would you like to play the extended game?");
            if (_isExtendedGame) { Console.WriteLine("Set phasers to fun! Just be careful of the Gorn..."); }
            bool choice = Helpers.BinaryChoice("A new game begins! Would you like to play against the computer?");

            switch (choice)
            {
                case true:
                    Console.WriteLine("\nA robotic challenger enters the arena!\n");
                    _players.Add(new Player("Mr Computer",true));
                    break;
                case false:
                    Console.WriteLine("\nI hope you brought a friend! Time to duke it out!");
                    Console.WriteLine("Hint: Cover your hand, so your opponent can't see your choice!\n");
                    _players.Add(new Player("Player 2", false));
                    break;
            }
            
        }
    }
}
