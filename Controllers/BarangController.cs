﻿using System.Net.Mime;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommer.Models;
using Ecommer.Models.Entities;

namespace Ecommer.Controllers;

public class BarangController : Controller
{
    private readonly ILogger<BarangController> _logger;
    private readonly AppDbContext _dbContext;

    public BarangController(ILogger<BarangController> logger, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Barang> barangs = _dbContext.Barangs.ToList();
        return View(barangs);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(BarangRequest newBarang)
    {
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
        if(!Directory.Exists(uploadFolder))
            Directory.CreateDirectory(uploadFolder);

        var Image = $"{newBarang.Kode}{newBarang.Image.FileName}";
        var filePath = Path.Combine(uploadFolder, Image);

        using var stream = System.IO.File.Create(filePath);
        if(newBarang.Image != null)
        {
            newBarang.Image.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{Image}";
        
        _dbContext.Barangs.Add(new Barang
        {
            Kode = newBarang.Kode,
            Nama = newBarang.Nama,
            Description = newBarang.Description,
            Harga = newBarang.Harga,
            Stok = newBarang.Stok,
            Image = Image,
            Url = url
        });
        return View();

    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Barang brg = _dbContext.Barangs.First(x => x.Id == id);
        return View(brg);
    }

    [HttpPost]
    public IActionResult Update(Barang brg)
    {
        try {
            Barang updated = _dbContext.Barangs.First(x => x.Id == brg.Id);
            updated.Kode = brg.Kode;
            updated.Nama = brg.Nama;
            updated.Description = brg.Description;
            updated.Harga = brg.Harga;
            updated.Stok = brg.Stok;
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
        Barang brg = _dbContext.Barangs.Find(id);
        _dbContext.Barangs.Remove(brg);
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
