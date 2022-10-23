using System;
using System.Net.Mime;
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
    public IActionResult Create(BarangRequest brg)
    {
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
        if(!Directory.Exists(uploadFolder))
            Directory.CreateDirectory(uploadFolder);

        var Image = $"{brg.Kode}{brg.Image!.FileName}";
        var filePath = Path.Combine(uploadFolder, Image);

        using var stream = System.IO.File.Create(filePath);
        if(brg.Image != null)
        {
            brg.Image.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Image/{Image}";

        Barang input = new Barang
        {
            IdPenjual = 14,
            Kode = brg.Kode,
            Nama = brg.Nama,
            Description = brg.Description,
            Harga = brg.Harga,
            Stok = brg.Stok,
            Image = Image,
            Url = url
        };
        _dbContext.Barangs.Add(input);
        _dbContext.SaveChanges();
        List<Barang> data = _dbContext.Barangs.ToList();
        return View("Index", data);

    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Barang brg = _dbContext.Barangs.First(x => x.Id == id);
        return View(brg);
    }


    [HttpPost]
    public IActionResult Update(BarangRequest brg)
    {
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
        var Image = $"{brg.Kode}{brg.Image.FileName}";
        var filePath = Path.Combine(uploadFolder, Image);
        using var stream = System.IO.File.Create(filePath);
        if(brg.Image != null)
        {
            brg.Image.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Image/{Image}";
            Barang updated = _dbContext.Barangs.First(x => x.Id == brg.Id);
            var DeletedfilePath = Path.Combine(uploadFolder,updated.Image!);
            System.IO.File.Delete(DeletedfilePath);
            // updated.Id = brg.Id;
            updated.Kode = brg.Kode;
            updated.Nama = brg.Nama;
            updated.Description = brg.Description;
            updated.Harga = brg.Harga;
            updated.Stok = brg.Stok;
            updated.Image = Image;
            updated.Url = url;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id) {
        Barang brg = _dbContext.Barangs.First(x => x.Id == id);
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
        var filePath = Path.Combine(uploadFolder,brg.Image!);
        System.IO.File.Delete(filePath);

        _dbContext.Barangs.Remove(brg);
        _dbContext.SaveChanges();
        List<Barang> barangs = _dbContext.Barangs.ToList();
        return View("Index", barangs);
    }
}
