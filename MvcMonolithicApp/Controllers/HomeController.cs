using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMonolithicApp.Models;
using MvcMonolithicApp.Models.DomainModels.PersonAggregate;
using MvcMonolithicApp.Models.DomainModels.ProductAggregate;

namespace MvcMonolithicApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Product()
    {
        return View("~/Views/Person/Index.cshtml");
    }

    public IActionResult Person()
    {
        return View("~/Views/Person/Index.cshtml");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}