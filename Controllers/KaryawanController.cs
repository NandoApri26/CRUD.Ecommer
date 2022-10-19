using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommer.Models;
using Ecommer.Models.Entities;

namespace Ecommer.Controllers;

public class KaryawanController : Controller
{
    private readonly ILogger<KaryawanController> _logger;
    private readonly AppDbContext _dbContext;

    public KaryawanController(ILogger<KaryawanController> logger, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Karyawan> karyawans = _dbContext.Karyawans.ToList();
        return View(karyawans);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Karyawan kry)
    {
        try {
            _dbContext.Karyawans.Add(kry);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        catch {
            return View();
        }
    }

    [HttpGet]
    public IActionResult Update(int Id )
    {
        Karyawan kry = _dbContext.Karyawans.First(x => x.IdKaryawan == Id);
        return View(kry);
    }

    [HttpPost]
    public IActionResult Update (Karyawan kry)
    {
        try {
            Karyawan updated = _dbContext.Karyawans.First(x => x.IdKaryawan == kry.IdKaryawan);
            updated.NamaKaryawan = kry.NamaKaryawan;
            updated.Username = kry.Username;
            updated.Posisi = kry.Posisi;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        catch {
            return View();
        }
    }

    [HttpGet]
    public ActionResult Delete(int Id)
    {
        Karyawan kry = _dbContext.Karyawans.Find(Id);
        _dbContext.Karyawans.Remove(kry);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}