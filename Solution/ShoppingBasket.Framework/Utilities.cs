using System;

namespace ShoppingBasket.Framework
{
    public static class Utilities
    {
        private const int MinValue = 1;
        private const int MaxValue = 100;

        /// <summary>
        /// Generates the random number.
        /// </summary>
        /// <returns>The random number.</returns>
        public static int GenerateRandomNumber()
        {
            var random = new Random();
            var number = random.Next(MinValue, MaxValue);
            return number;
        }
    }
}
