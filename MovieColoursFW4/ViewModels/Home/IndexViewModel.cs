using MovieColoursFW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieColoursFW4.ViewModels.Home
{
    public class IndexViewModel
    {
        public string Filename { get; set; }

        public int Size { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public DateTime DateCreated { get; set; }

        public AverageColor AverageColor { get; set; }


    }
}