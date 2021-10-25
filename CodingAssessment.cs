using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace myassessment
{
    public class CodingAssessment
    {
        public static void Main(string[] args)
        {
            // Initialize string variables for the paragraph and letter the user will enter
            string paragraph;
            char specialLetter;

            // Prompt the user to input the paragraph
            Console.WriteLine("\nPlease input your paragraph: ");
            paragraph = Console.ReadLine();
            // Prompt the user to input the letter
            Console.WriteLine("\nPlease input a single letter to check for all words containing that letter: ");
            specialLetter = Console.ReadLine()[0];

            // Check if the character the user entered is a letter
            bool isLetter = Char.IsLetter(specialLetter);
            // If it is not a valid letter, enter the while loop
            while(isLetter == false)
            {
                // Prompt the user to enter a valid letter
                Console.WriteLine("\nYou entered an invalid character. Please enter only a single letter: ");
                specialLetter = Console.ReadLine()[0];
                // Check the entered character again, loop will break if it is valid
                isLetter = Char.IsLetter(specialLetter);
            }

            // Create a new string variable to store the paragraph with all punctuation removed
            string noPunctuation = Regex.Replace(paragraph, @"[^\w\s]", "");

            // Create a new string variable to store the paragraph with any extra spaces removed
            string noExtraSpaces = Regex.Replace(noPunctuation, @"\s+", " ");

            // Create a new string variable to store the paragraph with all letters made lowercase
            string paragraphEdit = noExtraSpaces.ToLower();

            // Split the paragraph into an array of individual words
            string[] words = paragraphEdit.Split(' ');
            // Sort the words into alphabetical order
            Array.Sort(words);
            // Create a new list to store the unique words in
            List<string> uniqueWords = new List<string>();
            Console.WriteLine("\nList of unique words and how many times each word occurs: ");
            // Use a for loop to go through each word in the array
            for (int i = 0; i < words.Length; i++)
            {
                // Create a new int variable to keep track of the occurence of each word
                int count = 1;
                // Use a nested for loop to compare the current word to others in the array
                for(int j = i+1; j < words.Length; j++)
                {
                    // Check if the words are the same
                    if(words[i] == words[j])
                    {
                        // Increase the count of the word when there is another occurence
                        count++;
                    }
                    // Since the words are in alphabetical order, if the next word does not match, break the loop
                    else break;
                }
                // Make sure to only count each word's occurence amount once
                if(i == 0 || words[i-1] != words[i])
                {
                    // Add the unique word to the created list
                    uniqueWords.Add(words[i]);
                    // Write the word and the amount it appears to the console
                    Console.WriteLine("{0}, {1}", words[i], count);
                }
            }
            // Convert the list to an array
            string[] uniqueArray = uniqueWords.ToArray();
            // Create a new int variable to count the number of palindrome words
            int palWords = 0;
            // Create a new list to store the words that contain the user specified letter
            List<string> wordsWithLetter = new List<string>();
            // Go through each unique word in the array to check if it is a palindrome
            foreach(var word in uniqueArray)
            {
                // Ignore the case of the letter
                StringComparison comp = StringComparison.OrdinalIgnoreCase;
                // Check if the word contains the letter
                Boolean containsLetter = word.Contains(specialLetter, comp);
                // If the word contains the letter add it to the list
                if(containsLetter == true)
                {
                    wordsWithLetter.Add(word);
                }

                // Convert the word to an array of characters
                char[] letters = word.ToCharArray();
                // Reverse the characters in the array
                Array.Reverse(letters);
                // Convert the reversed characters to a string
                string rev = new string(letters);
                // Check if the reversed string is equal to the original string
                bool isPal = word.Equals(rev, StringComparison.OrdinalIgnoreCase);
                // If the boolean is true, the word is a palindrome
                if(isPal == true)
                {
                    // Increase the count of palindrome words by 1
                    palWords++;
                }
            }

            // Convert the list to an array
            string[] letterWords = wordsWithLetter.ToArray();
            // Check if there were no words added to the array
            if(letterWords == null || letterWords.Length == 0)
            {
                // Print to the console that no words containing the letter were found
                Console.WriteLine("\nThere are no words containing the specified letter {0}.", specialLetter);
            }
            // Else if there are words containing the letter
            else
            {
                // Print each word containing the specified letter to the console
                Console.WriteLine("\nWords containing the user specified letter {0}: ", specialLetter);
                foreach(var word in letterWords)
                {
                    Console.WriteLine(word);
                }
            }

            // Write the amount of unique palindrome words to the console
            Console.WriteLine("\nThere are {0} unique palindrome words.", palWords);

            // Create an array of sentences from the paragraph split by punctuation
            string[] sentences = paragraph.Split(new char[] {'.', '!', '?', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            // Create a new int variable to keep count of palindrome sentences
            int palSentences = 0;
            // Go through each sentence in the array to check for palindrome sentences
            foreach(var sentence in sentences)
            {
                // Remove all spaces in the sentence
                string noSpaces = String.Concat(sentence.Where(c => !Char.IsWhiteSpace(c)));
                // Convert the sentence into an array of characters
                char[] sentLetters = noSpaces.ToCharArray();
                // Reverse the characters
                Array.Reverse(sentLetters);
                // Convert reversed characters to a string
                string sentRev = new string(sentLetters);
                // Check if the reversed sentence is equal to the original
                bool isPalSent = noSpaces.Equals(sentRev, StringComparison.OrdinalIgnoreCase);
                // If they are equal, the count of palindrome sentences will increase by 1
                if(isPalSent == true)
                {
                    palSentences++;
                }
            }

            // Write the amount of palindrome sentences to the console
            Console.WriteLine("\nThere are {0} palindrome sentences.\n", palSentences);
        }
    }
}