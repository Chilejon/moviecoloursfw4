using System;

namespace MovieColoursFW4.Models
{
    public class Files
    {
        public string Filename { get; set; }

        public int Size { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public DateTime DateCreated { get; set; }

        public AverageColor AverageColor { get; set; }

    }
}