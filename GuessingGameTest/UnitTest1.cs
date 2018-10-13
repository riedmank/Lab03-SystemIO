using System;
using System.IO;
using Xunit;
using static GuessingGame.Program;

namespace GuessingGameTest
{
    public class UnitTest1
    {
        [Fact]
        public void CreatedFileExists()
        {
            CreateFile(path);
            Assert.True(File.Exists("../../../myFile.txt"));
        }

        [Fact]
        public void CanReadFile()
        {
            Assert.NotEmpty(ReadAFile(path));
        }

        [Fact]
        public void CanAppendFile()
        {
            string word = "harkonnen";
            AppendAFile(path, word);
            Assert.Contains(word, ReadAFile(path));
        }

        [Fact]
        public void CanRemoveFromFile()
        {
            string word = "potato";
            RemoveAWord(path, word);
            Assert.DoesNotContain(word, ReadAFile(path));
        }

        [Fact]
        public void DeletedFileDoesNotExist()
        {
            DeleteAFile(path);
            Assert.False(File.Exists("../../../myFile.txt"));
        }

        [Fact]
        public void LetterDoesExistInChosenWord()
        {
            char[] charLetterArray = "kaitain".ToCharArray();
            string[] lettersToGuess = CharToStringConverter(charLetterArray);
            string userGuess = "a";
            string[] emptyGuess = new string[lettersToGuess.Length];
            emptyGuess = Fill(emptyGuess);
            CheckUserGuess(lettersToGuess, userGuess, emptyGuess);
            Assert.Contains(userGuess, emptyGuess);
        }

        [Fact]
        public void LetterDoesNotExistInChosenWord()
        {
            char[] charLetterArray = "kaitain".ToCharArray();
            string[] lettersToGuess = CharToStringConverter(charLetterArray);
            string userGuess = "d";
            string[] emptyGuess = new string[lettersToGuess.Length];
            emptyGuess = Fill(emptyGuess);
            CheckUserGuess(lettersToGuess, userGuess, emptyGuess);
            Assert.DoesNotContain(userGuess, emptyGuess);
        }
    }
}
