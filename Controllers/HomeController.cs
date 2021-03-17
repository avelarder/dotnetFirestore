using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetFirebase.Models;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Facades;

namespace dotnetFirebase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFirestoreDbService _fbService;

        public HomeController(ILogger<HomeController> logger, IFirestoreDbService fbService)
        {
            _logger = logger;
            _fbService = fbService;
        }

        public IActionResult Index()
        {
            var collection = _fbService.GetTeams();
            return View(collection);
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
