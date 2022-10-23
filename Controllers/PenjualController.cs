using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommer.Models;
using Ecommer.Models.Entities;

namespace Ecommer.Controllers;

public class PenjualController : Controller
{
    private readonly ILogger<PenjualController> _logger;
    private readonly AppDbContext _dbContext;

    public PenjualController(ILogger<PenjualController> logger, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Penjual> penjuals = _dbContext.Penjuals.ToList();
        return View(penjuals);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Penjual pen)
    {
        try {
            pen.IdUser=9;
            _dbContext.Penjuals.Add(pen);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        catch{
            return View();
        }
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Penjual pen = _dbContext.Penjuals.First(x => x.Id == id);
        return View(pen);
    }

    public IActionResult Update(Penjual pen)
    {
        try {
            Penjual updated = _dbContext.Penjuals.First(x => x.Id == pen.Id);
            updated.NamaToko = pen.NamaToko;
            updated.Alamat = pen.Alamat;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        catch {
            return View();
        }
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        Penjual pen = _dbContext.Penjuals.Find(id)!;
        _dbContext.Penjuals.Remove(pen);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
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