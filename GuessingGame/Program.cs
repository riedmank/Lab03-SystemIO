using System;
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
        public static void AppendAWord(string path, string wordToAdd)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(wordToAdd);                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                throw e;
            }
            Console.WriteLine("Action Successful!");
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
            catch (Exception e)
            {
                Console.WriteLine("Error");
                throw e;
            }
            Console.WriteLine("Action successful");
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
                    Admin();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void Admin()
        {
            int userChoice = 0;
            Console.WriteLine("Admin menu. Please choose one of the following.");
            Console.WriteLine("1. Add a word.");
            Console.WriteLine("2. Delete a word.");
            try
            {
                userChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            switch (userChoice)
            {
                case 1:
                    AppendAWord(path, Console.ReadLine());
                    break;
                case 2:
                    RemoveAWord(path, Console.ReadLine());
                    break;
                default:
                    Menu();
                    break;
            }
            Menu();
        }

        /// <summary>
        /// This method is the meat of the game and calls all the methods required to play the game
        /// </summary>
        /// <param name="choice">Takes in a random number generated in menu</param>
        public static void GuessingGame(int randomNumber)
        {
            string[] wordsFromFile = ReadAFile(path);
            char[] charLetterArray = wordsFromFile[randomNumber].ToCharArray();
            string[] lettersToGuess = CharToStringConverter(charLetterArray);
            string guesses = "";
            string userGuess = "";
            string[] emptyGuess = new string[lettersToGuess.Length];
            emptyGuess = Fill(emptyGuess);
            bool roundFinished = false;
            while (!roundFinished)
            {
                Console.WriteLine("Guess a letter.");
                PrintArray(emptyGuess);
                try
                {
                    userGuess = Console.ReadLine();
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                emptyGuess = CheckUserGuess(lettersToGuess, userGuess, emptyGuess);
                roundFinished = CheckForWin(emptyGuess);
                if (!roundFinished)
                {
                    guesses += userGuess;
                    Console.WriteLine($"Guesses so far: {guesses}");
                }
            }
            if (roundFinished)
            {
                Console.WriteLine("You Won!!");
                Menu();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lettersToGuess"></param>
        /// <param name="userGuess"></param>
        /// <param name="emptyGuess"></param>
        /// <returns></returns>
        public static string[] CheckUserGuess(string[] lettersToGuess, string userGuess, string[] emptyGuess)
        {
            for (int i = 0; i < lettersToGuess.Length; i++)
            {
                if (lettersToGuess[i] == userGuess)
                {
                    emptyGuess[i] = lettersToGuess[i];
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
        /// Prints array of values to the console.
        /// </summary>
        /// <param name="arrayToPrint">Takes in an array to be printed to the console.</param>
        public static void PrintArray(string[] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                Console.Write(arrayToPrint[i]);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Converts char array into string array
        /// </summary>
        /// <param name="charLetterArray">Takes in a char array</param>
        /// <returns>Returns a string array</returns>
        public static string[] CharToStringConverter(char[] charLetterArray)
        {
            string[] convertedCharArray = new string[charLetterArray.Length];
            for (int i = 0; i < charLetterArray.Length; i++)
            {
                convertedCharArray[i] = charLetterArray[i].ToString();
            }
            return convertedCharArray;
        }
    }
}
