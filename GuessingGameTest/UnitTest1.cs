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

        }

        [Fact]
        public void LetterDoesNotExistInChosenWord()
        {

        }
    }
}
