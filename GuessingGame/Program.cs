using System;
using System.IO;

namespace GuessingGame
{
    public class Program
    {
        public static string path = "../../../myFile.txt";
        public static void Main(string[] args)
        {
            CreateFile(path);
            AppendAFile(path, "potato");
            string[] words = ReadAFile(path);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
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
        public static void AppendAFile(string path, string word)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(word);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
