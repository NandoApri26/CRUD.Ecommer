using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommer.Models;
using Ecommer.Models.Entities;

namespace Ecommer.Controllers;

public class PembeliController : Controller
{
    private readonly ILogger<PembeliController> _logger;
    private readonly AppDbContext _dbContext;

    public PembeliController(ILogger<PembeliController> logger, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Pembeli> pembelis = _dbContext.Pembelis.ToList();
        return View(pembelis);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Pembeli pem)
    {
        try {
            pem.IdUser=10;
            _dbContext.Pembelis.Add(pem);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        catch {
            return View();
        }
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Pembeli pem = _dbContext.Pembelis.First(x => x.IdPembeli == id);
        return View(pem);
    }

    [HttpPost]
    public IActionResult Update(Pembeli pem)
    {
        try {
            Pembeli updated = _dbContext.Pembelis.First(x => x.IdPembeli == pem.IdPembeli);
            updated.Nama = pem.Nama;
            updated.Alamat = pem.Alamat;
            updated.NoHp = pem.NoHp;
            updated.Negara = pem.Negara;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        Pembeli pem = _dbContext.Pembelis.Find(id);
        _dbContext.Pembelis.Remove(pem);
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