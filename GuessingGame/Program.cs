﻿using System;
using System.IO;

namespace GuessingGame
{
    public class Program
    {
        public static string path = "../../../myFile.txt";
        public static void Main(string[] args)
        {
            Menu();
        }

        /// <summary>
        /// This method creates a file and writes to it
        /// </summary>
        /// <param name="path">Path to file location</param>
        public static void CreateFile(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.WriteLine("sandworm");
                        sw.WriteLine("fremen");
                        sw.WriteLine("mentat");
                        sw.WriteLine("navigator");
                        sw.WriteLine("arrakis");
                        sw.WriteLine("potato");
                        sw.WriteLine("melange");
                        sw.WriteLine("crysknife");
                        sw.WriteLine("caladan");
                        sw.WriteLine("kralizec");
                        sw.WriteLine("atreides");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// This method deletes a file
        /// </summary>
        /// <param name="path">Path to file location</param>
        public static void DeleteAFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// This method reads a file
        /// </summary>
        /// <param name="path">Path to file location</param>
        /// <returns>Array of strings from the file</returns>
        public static string[] ReadAFile(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {                  
                    string[] words = File.ReadAllLines(path);
                    return words;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method adds a word to the text file
        /// </summary>
        /// <param name="path">Path to the file location</param>
        /// <param name="word">User provided string to add to file</param>
        public static void AppendAFile(string path, string wordToAdd)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(wordToAdd);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// This method removes a word from the file
        /// </summary>
        /// <param name="path">Path to the file location</param>
        /// <param name="wordToRemove">User provided string to remove from file</param>
        public static void RemoveAWord(string path, string wordToRemove)
        {
            try
            {
                string[] currentWords = ReadAFile(path);
                string[] newWords = new string[currentWords.Length - 1];
                int counter = 0;
                for (int i = 0; i < currentWords.Length; i++)
                {
                    if (wordToRemove == currentWords[i])
                    {
                        continue;
                    }
                    else
                    {
                        newWords[counter] = currentWords[i];
                        counter++;
                    }
                }
                File.WriteAllLines(path, newWords);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// This methods selects a random number
        /// </summary>
        /// <returns>Returns a random number</returns>
        public static int RandomNumberGenerator()
        {
            Random rand = new Random();
            int randomNum = rand.Next(1, ReadAFile(path).Length);
            return randomNum;
        }

        /// <summary>
        /// User interface for game menu
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine("Welcome to the Guessing Game.");
            Console.WriteLine("Select an option from below.");
            Console.WriteLine("1. Play Guessing Game");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Exit");

            int userInput = 0;

            try
            {
                userInput = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Menu();
            }
            switch (userInput)
            {
                case 1:
                   GuessingGame(RandomNumberGenerator());
                    break;
                case 2:
                    //Admin();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void GuessingGame(int choice)
        {
            string[] wordsFromFile = ReadAFile(path);
            string[] lettersToGuess = wordsFromFile[choice].Split("");
            string[] guesses = new string[26];
            string userGuess = "";
            int counter = 0;
            string[] emptyGuess = new string[lettersToGuess.Length];
            emptyGuess = Fill(emptyGuess);
            bool roundFinished = false;
            while (!roundFinished)
            {
                Console.WriteLine("Guess a letter.");
                try
                {
                    userGuess = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                emptyGuess = CheckUserGuess(lettersToGuess, userGuess, emptyGuess);
                PrintArray(emptyGuess);
                roundFinished = CheckForWin(emptyGuess);
                if (!roundFinished)
                {
                    GuessesSoFar(userGuess, counter, guesses);
                }
            }
            Menu();
        }

        public static string[] CheckUserGuess(string[] lettersToGuess, string userGuess, string[] emptyGuess)
        {
            for (int i = 0; i < lettersToGuess.Length; i++)
            {
                if (lettersToGuess[i] == userGuess)
                {
                    emptyGuess[i] = lettersToGuess[i];
                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.WriteLine("Wrong");
                }
            }
            return emptyGuess;
        }

        /// <summary>
        /// This methods checks to see if the user won the game
        /// </summary>
        /// <param name="emptyGuess">Takes in the emptyGuess array from GuessingGame</param>
        /// <returns>Returns true if array does not contain " _ " otherwise returns false</returns>
        public static bool CheckForWin(string[] emptyGuess)
        {
            bool win = true;
            foreach (string el in emptyGuess)
            {
                if (el == " _ ")
                {
                    win = false;
                }
            }
            return win;
        }

        /// <summary>
        /// Fills string array with empty spaces
        /// </summary>
        /// <param name="arrayToBeFilled">Array passed from GuessingGame method</param>
        /// <returns>Returns a string array fille with " _ "</returns>
        public static string[] Fill(string[] arrayToBeFilled)
        {
            for (int i = 0; i < arrayToBeFilled.Length; i++)
            {
                arrayToBeFilled[i] = " _ ";
            }
            return arrayToBeFilled;
        }

        /// <summary>
        /// This method keeps track of user guesses and prints them to the console.
        /// </summary>
        /// <param name="userGuess">User provided guess</param>
        /// <param name="counter">Tells program where to store userGuess</param>
        /// <param name="guesses">Array of guesses</param>
        public static void GuessesSoFar(string userGuess, int counter, string[] guesses)
        {
            guesses[counter] = userGuess;
            Console.Write("Guesses so far: ");
            for (int i = 0; i < guesses.Length; i++)
            {
                if (guesses[i] == null)
                {
                    break;
                }
                else
                {
                    Console.Write($"{guesses[i]} ");
                }
            }
        }

        /// <summary>
        /// Prints array of values to the console.
        /// </summary>
        /// <param name="arrayToPrint">Takes in an array to be printed to the console.</param>
        public static void PrintArray(string[] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                Console.Write(arrayToPrint[i]);
            }
        }
    }
}
