using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerFinder.Context;
using ServerFinder.Models;

namespace ServerFinder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MainDbContext _context;

    public HomeController(ILogger<HomeController> logger, MainDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index([FromQuery] string sortDirection, [FromQuery] string sortSource = "price")
    {
        var list = _context.TblServers.Include("CompanyNavigation").Include("ProcessorNavigation");
        
        // Super awesome list sort
        
        switch (sortSource)
        {
            case "price":
                list = sortDirection == "desc" ? 
                    list.OrderByDescending(s => s.PriceGbp) : list.OrderBy(s => s.PriceGbp);
                break;
            case "storage":
                list = sortDirection == "desc" ? 
                    list.OrderByDescending(s => s.TotalStorage) : list.OrderBy(s => s.TotalStorage);
                break;
            case "ram":
                list = sortDirection == "desc" ? 
                    list.OrderByDescending(s => s.Ram) : list.OrderBy(s => s.Ram);
                break;
            case "pthreads":
                list = sortDirection == "desc" ? 
                    list.OrderByDescending(s => s.ProcessorNavigation.PThreads) : list.OrderBy(s => s.ProcessorNavigation.PThreads);
                break;
            case "pcores":
                list = sortDirection == "desc" ? 
                    list.OrderByDescending(s => s.ProcessorNavigation.PCores) : list.OrderBy(s => s.ProcessorNavigation.PCores);
                break;
        }
        
        return View(await list.ToListAsync());
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