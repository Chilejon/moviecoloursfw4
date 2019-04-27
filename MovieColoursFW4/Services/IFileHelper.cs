using Emgu.CV;
using Emgu.CV.Structure;
using MovieColoursFW4.Models;
using System.Collections.Generic;
using System.Drawing;

namespace MovieColoursFW4.Services
{
    interface IFileHelper
    {
        List<Files> GetFiles(string directory);


        Image<Bgr, byte> PixelateImage(Image<Bgr, byte> image);


        AverageColor DoSumit(string path);


        void ProcessAVideo(string path, string outputPath);

    }
}
