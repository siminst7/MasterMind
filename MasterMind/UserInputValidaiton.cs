using System;
using System.Linq;

namespace MasterMind
{
    public class UserInputValidaiton
    {
        public static bool IsUserInputValid(char[] input)
        {
            if (input.Length > 4)
            {
                return false;
            }

            foreach (char digit in input)
            {
                int num;
                if (!int.TryParse(digit.ToString(), out num))
                {
                    return false;                
                }
            }
            return true;
        }

        public static string GetInputEvaluation(char[] randomNum, char[] input)
        {
            string positiveResult = "";
            string negativeResult = "";
            for(int i = 0; i< input.Length; i++)
            {
                if (input[i] == randomNum[i])
                {
                    positiveResult += " + ";
                    randomNum[i] = ' ';
                    input[i] = ' ';
                }            
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (randomNum.Any(z => z == input[i] && z != ' '))
                {
                    int randomNumberIndex = Array.IndexOf(randomNum, input[i]);
                    randomNum[randomNumberIndex] = ' ';
                    negativeResult += " - ";
                }
            }
            return positiveResult + negativeResult;

        }
        
    }
}
