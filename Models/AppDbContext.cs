using Microsoft.EntityFrameworkCore;
using Ecommer.Models.Entities;

namespace Ecommer.Models;

public class AppDbContext: DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Barang> Barangs { get; set; }
    public DbSet<Penjual> Penjuals { get; set; }
    public DbSet<Pembeli> Pembelis { get; set; }
    public DbSet<Karyawan> Karyawans { get; set; }
}