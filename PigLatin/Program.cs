using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Or should I say Ellohay!" +
                "\nLets start translating English to Pig Latin!");

            bool again = true;
            while (again)
            {
                Console.WriteLine("Enter a word you'd like translated to Pig Latin.");
                string userWord = Console.ReadLine();
                //check its a valid word method
                bool wordIs = WordCheck(userWord);
                    if (wordIs == true)
                    {
                        Console.WriteLine("Is a word!");
                    //finds any space between words and first vowel in word to split
                    var wordSplit = WordList(userWord);
                    Console.WriteLine(wordSplit);
                    //ask if they want to loop
                    again = Again();
                    }
                    else
                    {
                    Console.WriteLine("Sorry I'm not sure that was a word, please try again.");
                    again = true;
                    }
            }
        }
        public static bool WordCheck(string input)
        {
            ////checks for any digit or nonletter char in string
            bool noError = Regex.IsMatch(input, @"^([A-Za-z]+\s|'|-?[A-Za-z]\s|'|-?[A-Za-z][A-Za-z]+\s+[A-Za-z]*|'|-?[A-Za-z])*$");
            //returns true if it is a word type entry, returns false if any number/symbol exists
            return noError;
        }

        public static string WordList(string input)
        {
            var newSentence = "";
            const string vowels = "AEIOUaeiou";
            List<string> newWord = new List<string>();
            //space/words check
            foreach (var word in input.Split(' '))
            {
                var firstLetter = word.Substring(0, 1);
                var restOfword = word.Substring(1, word.Length - 1);
                var currentLetter = vowels.IndexOf(firstLetter, StringComparison.Ordinal);

                if (currentLetter == -1)
                {
                    newSentence += restOfword + firstLetter + "ay ";
                }
                else
                {
                    newSentence += word + "way ";
                }
            }
            return newSentence;
        }
        public static bool Again()
        {
            Console.WriteLine("\nIf you want to translate more enter: Yes\n If you want to exit enter anything else");
            string loop = Console.ReadLine().ToLower();
            if (loop == "y" || loop == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
