using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class Helpers
    {
        public static bool BinaryChoice(string message)
        {
            Console.Write($"{message} (Y/N): ");
            char choice = Console.ReadLine().ToUpper()[0];

            switch (choice)
            {
                case 'Y':
                    return true;
                case 'N':
                    return false;
                default:
                    return false;
            }
        }
    }
}
