using Microsoft.AspNetCore.Mvc;
using System;
using SiLPPM_New_Version.Models;
using SiLPPM_New_Version.DAO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Dynamic;

namespace SiLPPM_New_Version.Controllers
{
    public class HomeController : Controller
    {
        PenelitianDAO penelitianDAO;
        dynamic myobj;
        
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
            _logger = logger;
        }

        public IActionResult Index()
        {
            var count = penelitianDAO.GetCountPenelitian();
            var countSelesai = penelitianDAO.GetCountPenelitianSelesai();
            var countMenungguReview = penelitianDAO.GetCountPenelitianMenungguReview();
            var countPengabdian = penelitianDAO.GetCountPengabdian();
            myobj.countSelesai = countSelesai.data;
            myobj.countPengabdian = countPengabdian.data;
            myobj.countMenungguReview = countMenungguReview.data;
            myobj.count = count.data;
            return View(myobj);
        }
        public IActionResult IndexReviewer()
        {
            return View();
        }
        public IActionResult IndexPustakawan()
        {
            return View();
        }
        public IActionResult IndexAdmin()
        {
            return View();
        }
        public IActionResult IndexDosen()
        {
            return View();
        }
        public IActionResult IndexKALPPM()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}