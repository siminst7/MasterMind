using System;

namespace MasterMind
{
    public class RandomNumberGenerator
    {
        private static readonly Random _random = new Random();

        public static string RandomNumber()
        {
            string randomNum = "";
            for (int i = 0; i < 4; i++)
            {
               var digit = _random.Next(1, 6);
                randomNum += digit;
            }
            return randomNum;
        }
    }
}
