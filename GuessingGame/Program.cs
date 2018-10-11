using System;
using System.IO;

namespace GuessingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateFile();
        }

        public static void CreateFile()
        {
            string path = "../../../myFile.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                    sw.WriteLine("sandworm");
                    }
                    catch (Exception)
                    {
                        throw;
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
    }
}
