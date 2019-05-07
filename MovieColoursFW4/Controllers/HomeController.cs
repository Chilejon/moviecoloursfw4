using MovieColoursFW4.Models;
using MovieColoursFW4.Services;
using MovieColoursFW4.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieColoursFW4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            FileHelper FH = new FileHelper();

            string directory = "c:\\moviepictures\\";

            List<Files> AllFiles = FH.GetFiles(directory);

            IndexViewModel viewModel = new IndexViewModel();

            viewModel.Filename = AllFiles[0].Filename;
            viewModel.DateCreated = AllFiles[0].DateCreated;
            viewModel.AverageColor = AllFiles[0].AverageColor;
            viewModel.Height = AllFiles[0].Height;
            viewModel.Width = AllFiles[0].Width;


            ViewBag.Hex = viewModel.AverageColor.Hex;


            return View(viewModel);
        }



        public ActionResult ShowImages()
        {

            FileHelper FH = new FileHelper();

            //string directory = "c:\\moviepictures\\";
            string directory = "C:\\Users\\JonC\\Videos\\sw";

            List<Files> AllFiles = FH.GetFiles(directory);

            List<IndexViewModel> viewModel = new List<IndexViewModel>();


            int count = 0;

            foreach (var item in AllFiles.Reverse<Files>())
            {
                if (count%2 == 0)
                {

                    IndexViewModel vm = new IndexViewModel();

                    vm.Filename = item.Filename;
                    vm.DateCreated = item.DateCreated;
                    vm.AverageColor = item.AverageColor;
                    vm.Height = item.Height;
                    vm.Width = item.Width;

                    viewModel.Add(vm);
                }
                count++;

            }




            return View(viewModel);
        }
    }
}