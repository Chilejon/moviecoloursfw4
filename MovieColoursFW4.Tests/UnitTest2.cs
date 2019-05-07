using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieColoursFW4.Models;
using MovieColoursFW4.Services;

namespace MovieColoursFW4.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void FileCountShouldBe2()
        {

            //Arrange
            FileHelper FH = new FileHelper();
            string directory = @"c:\moviepictures\";

            //Act

            List<Files> AllFiles = FH.GetFiles(directory);


            //Assert
            Assert.AreEqual(2, AllFiles.Count);

        }


        [TestMethod]
        public void GetsFullDetailsOfFiles()
        {

            //Arrange
            FileHelper FH = new FileHelper();
            string directory = "c:\\moviepictures\\";

            //Act

            List<Files> AllFiles = FH.GetFiles(directory);



            //Assert
            Assert.AreEqual("red.png", AllFiles[0].Filename);
            Assert.AreEqual(234, AllFiles[0].AverageColor.R);
        }


        [TestMethod]
        public void ReadAVideo()
        {
            FileHelper FH = new FileHelper();

            string videoPath = "C:\\Users\\JonC\\Videos\\sw.mp4";
            string outPath = "C:\\Users\\JonC\\Videos\\sw";

            FH.ProcessAVideo(videoPath, outPath);


        }

    }
}
