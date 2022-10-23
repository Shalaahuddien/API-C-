// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Mendata.Net;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Infrastructure;
// using System.Text;
// using Microsoft.Net.Http.Headers;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
// using Microsoft.AspNetCore.Authentication;
// using System.Security.Claims;
// using Microsoft.AspNetCore.Mvc.Filters;

// namespace Mendata.Net.Controllers;

// public class HomeController : Controller
// {
//     private readonly ILogger<HomeController> _logger;

//     public HomeController(ILogger<HomeController> logger)
//     {
//         _logger = logger;
//     }

//     public IActionResult Index()
//     {
//         return View();
//     }

//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }
