using System;

namespace MasterMind
{
    class Program
    {
        private static readonly int _maxTry = 10;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MasterMind!\n");
            Console.WriteLine("How to Play: \n");
            Console.WriteLine("Enter a 4-digi number. \n");
            Console.WriteLine("if input is not a 4-digit number you will lose a turn. \n");

            MasterMind();
        }

        private static void MasterMind()
        {
            string randomNum = RandomNumberGenerator.RandomNumber();
           
            Console.WriteLine("Please enter your first number");
            for (int i = 1; i <= _maxTry; i++)
            {
                string userGuess = Console.ReadLine();
                char[] input = userGuess.ToCharArray();
                if (string.IsNullOrEmpty(userGuess) || !UserInputValidaiton.IsUserInputValid(input))
                {
                    Console.WriteLine("You lost one turn, please enter a valid 4-digit number");
                    continue ;
                }
                if (userGuess == randomNum)
                {
                    Console.WriteLine($"Good Job!");
                    break;
                }
                Console.WriteLine($"Guess number {i}: {UserInputValidaiton.GetInputEvaluation(randomNum.ToCharArray(), input)}");
            }
            Console.WriteLine($"{randomNum} is the correct number.");

        }
    }
}
