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
            CreateFile();
            Assert.True(File.Exists("../../../myFile.txt"));
        }
    }
}
