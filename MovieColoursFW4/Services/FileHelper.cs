using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using MovieColoursFW4.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

namespace MovieColoursFW4.Services
{
    public class FileHelper : IFileHelper
    {

        public List<Files> GetFiles(string directory)
        {
            var dir = new DirectoryInfo(directory);
            FileInfo[] allFiles = dir.GetFiles();

            List<Files> allFilesList = new List<Files>();


            foreach (var item in allFiles)
            {

                if (item.FullName.Contains("jpeg") || item.FullName.Contains("png"))
                {
                    var file = new Files();
                    file.DateCreated = item.CreationTime;
                    file.Filename = item.Name;


                    Image img = Image.FromFile(item.FullName);
                    file.Height = img.Height;
                    file.Width = img.Width;
                    file.Size = img.Height * img.Width;

                    //Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(item.FullName);

                    //var pI = PixelateImage(img1);

                    //img.Dispose();

                    //pI.Save(item.FullName);

                    AverageColor rgb = DoSumit(item.FullName);

                    file.AverageColor = rgb;

                    allFilesList.Add(file);
                }
            }


            List<Files> SortedList = allFilesList.OrderBy(o => o.DateCreated).ToList();




            return SortedList;
        }

        public Image<Bgr, byte> PixelateImage(Image<Bgr, byte> image)
        {
            return image.Resize((int)(image.Width * .25), (int)(image.Height * .25), Inter.Area)
                .Resize(image.Width, image.Height, Inter.Nearest);
        }


        public AverageColor DoSumit(string path)
        {

            Bitmap bmp = new Bitmap(1, 1);
            Bitmap orig = (Bitmap)Bitmap.FromFile(path);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // updated: the Interpolation mode needs to be set to 
                // HighQualityBilinear or HighQualityBicubic or this method
                // doesn't work at all.  With either setting, the results are
                // slightly different from the averaging method.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(orig, new Rectangle(0, 0, 1, 1));
            }
            Color pixel = bmp.GetPixel(0, 0);
            // pixel will contain average values for entire orig Bitmap

            AverageColor rgb = new AverageColor() { R = pixel.R, G = pixel.G, B = pixel.B };

            byte avgR = pixel.R; // etc.

            Color myColor = Color.FromArgb(pixel.R, pixel.G, pixel.B);

            rgb.Hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");

            return rgb;
        }

        public void ProcessAVideo(string path, string outputPath)
        {

            using (var engine = new Engine())
            {
                var mp4 = new MediaFile { Filename = path };

                engine.GetMetadata(mp4);
                
                var i = 7500;
                //var ii = 1;
                while (i  > 1)
                {
                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(i) };
                    var outputFile = new MediaFile { Filename = string.Format("{0}\\image-{1}.jpeg", outputPath, i) };
                    engine.GetThumbnail(mp4, outputFile, options);
                    i = i -1;
                  //  ii++;
                }
            }

        }
    }
}
