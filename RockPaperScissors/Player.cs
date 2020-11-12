using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RockPaperScissors
{
    class Player
    {
        // Properties
        public PlayerType PlayerType { get { return _playerType; } }
        public string Name { get { return _name; } }
        public List<Move> Moves { get { return _moves; } }

        // Members
        private PlayerType _playerType;
        private string _name;
        private List<Move> _moves;

        // Methods
        public void MakeMove(bool exGame)
        {
            if (PlayerType == PlayerType.AI)
            {
                Console.WriteLine($"{Name} is thinking.");
                Thread.Sleep(500);
                Console.WriteLine("[Move Recieved!]\n");
                int choice;
                if (exGame)
                {
                    choice = new Random().Next(0, 5);
                }
                else
                {
                    choice = new Random().Next(0, 3) * 2;
                }
                
                _moves.Insert(0, (Move)choice);
            }
            else
            {
                ConsoleKeyInfo key;

                Console.WriteLine($"{Name}, it's time to make your move!");
                

                if (exGame)
                {
                    Console.WriteLine("Q = Rock, W = Paper, E = Scissors, R = Lizard, T = Spock");
                    do
                    {
                        key = Console.ReadKey(true);
                    }
                    while (key.Key != ConsoleKey.Q && key.Key != ConsoleKey.W && key.Key != ConsoleKey.E && key.Key != ConsoleKey.R && key.Key != ConsoleKey.T);
                }
                else
                {
                    Console.WriteLine("Q = Rock, W = Paper, E = Scissors");
                    do
                    {
                        key = Console.ReadKey(true);
                    }
                    while (key.Key != ConsoleKey.Q && key.Key != ConsoleKey.W && key.Key != ConsoleKey.E);
                }


                Console.WriteLine("[Move Recieved!]\n");

                switch (key.Key.ToString())
                {
                    case "Q":
                        _moves.Insert(0, Move.Rock);
                        break;
                    case "W":
                        _moves.Insert(0, Move.Paper);
                        break;
                    case "E":
                        _moves.Insert(0, Move.Scissors);
                        break;
                    case "R":
                        _moves.Insert(0, Move.Lizard);
                        break;
                    case "T":
                        _moves.Insert(0, Move.Spock);
                        break;
                }

                Thread.Sleep(500);
            }
            
        }


        // Constructor
        public Player(string name, bool ai)
        {
            if (ai)
            {
                _playerType = PlayerType.AI;
            }
            else
            {
                _playerType = PlayerType.Human;
            }

            _name = name;
            _moves = new List<Move>();
        }
    }

    enum PlayerType
    {
        Human,
        AI
    }

    enum Move: byte
    {
        Rock = 0,
        Spock = 1,
        Paper = 2,
        Lizard = 3,
        Scissors = 4
    } 
}
