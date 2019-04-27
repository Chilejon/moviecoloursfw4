using MovieColoursFW4.Models;
using MovieColoursFW4.Services;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MovieColoursFW4.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanReadTheDirectory()
        {
            //Arrange
            FileHelper FH = new FileHelper();
            string directory = @"c:\moviepictures\";

            //Act

            List<Files> AllFiles = FH.GetFiles(directory);


            //Assert
            Assert.Equal(2, AllFiles.Count);

        }

        [Fact]
        public void GetsFullDetailsOfFiles()
        {

            //Arrange
            FileHelper FH = new FileHelper();
            string directory = "c:\\moviepictures\\";

            //Act

            List<Files> AllFiles = FH.GetFiles(directory);


            //Assert
            Assert.Equal("one.bmp", AllFiles[0].Filename);
        }
    }
}




namespace MovieColoursTests
{
    public class UnitTest1
    {
        
    }
}
