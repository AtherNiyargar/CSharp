/* Note that this program works properly when run in the console and is intended for the same use */

using System;

// This is a namespace that provides the features that are useful in
// creating array, list, dictionary, etc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Guess_the_number {
    internal class Random_Word {

        int word_category, word_num;

        string[,] random_word = new string[4, 18] {

                {"USA", "Canada", "China", "India", "Germany",
                    "France", "Japan", "Brazil", "Russia", "Australia", "Italy", "Mexico",
                    "Spain", "Korea", "Egypt", "Turkey", "Sweden",    "Country" },

                {"Head", "Arm", "Leg", "Hand", "Foot", "Eye", "Ear", "Nose", "Mouth",
                    "Finger", "Knee", "Elbow", "Shoulder", "Chest", "Back", "Stomach",
                    "Neck",    "Body Part" },

                {"Teacher", "Doctor", "Engineer", "Nurse", "Lawyer", "Accountant", "Scientist",
                    "Chef", "Farmer", "Mechanic", "Electrician", "Plumber", "Artist", "Writer",
                    "Pilot", "Police", "Carpenter",    "Profession" },

                {"Dog", "Cat", "Cow", "Horse", "Sheep", "Pig", "Goat", "Elephant", "Tiger",
                    "Lion", "Bear", "Monkey", "Rabbit", "Deer", "Frog", "Snake",
                    "Panda",     "Animal"}
            };

        internal string word_Provider() {
            return random_word[word_category, word_num];
        }
        public Random_Word() {

            Random random_num_gen = new Random();
            word_category = random_num_gen.Next(0, 4);
            word_num = random_num_gen.Next(0, 17);

        }
        internal string category_provider() {
            return random_word[word_category, 17];
        }
    }

    public class Hangman {
        public static void Main(string[] args) {
            char user_ch;
            Random_Word random_word_obj = new Random_Word();
            string word_to_guess = random_word_obj.word_Provider();
            string word_category = random_word_obj.category_provider();
            int wordLength = word_to_guess.Length;
            int lives = 3;
            bool match_found = false;
            Console.Clear();

            int correct_attempts = 0;
            char[] unrevealed = new char[wordLength];
            for (int i = 0; i < wordLength; i++) {
                unrevealed[i] = '_';
            }
            while (correct_attempts != wordLength) {
                Console.Clear();
                // Console.WriteLine(word_to_guess);
                Console.WriteLine($"Enter your guessd letter! It is of type {word_category}. You have {lives} lives!");
                Console.WriteLine(unrevealed);
                user_ch = Console.ReadKey().KeyChar;
                Console.Clear();
                for (int i = 0; i < wordLength; i++) {
                    if (user_ch == word_to_guess[i] && unrevealed[i] == '_') {
                        unrevealed[i] = user_ch;
                        correct_attempts++;
                        match_found = true;
                    }
                }
                if (match_found) {
                    match_found = false;
                }
                else {
                    lives--;
                }
                if(lives == 0) {
                    Console.WriteLine($"Game Over. The word was {word_to_guess}!");
                    break;
                }
            }
        }
    }
}
