using System;

namespace Guess_the_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!\nThee number is decided! Guess it");
            int user_guess, bot_guess, attempts = 0;
            Random rand_num_gen = new Random();
            bot_guess = rand_num_gen.Next(1, 101);

            do
            {
                user_guess = Convert.ToInt32(Console.ReadLine());
                if (user_guess > bot_guess)
                {
                    Console.WriteLine("Guess a lower number");
                    attempts++;
                }
                else if (user_guess < bot_guess)
                {
                    Console.WriteLine("Guess a higher number");
                    attempts++;
                }
                else
                {
                    Console.WriteLine($"You have guess the number in {attempts} attempts!");
                }
            } while (user_guess != bot_guess);
        }
    }
}
