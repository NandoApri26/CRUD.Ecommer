using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommer.Models.Entities;

public class Pembeli {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int IdPembeli {get; set;}
    [StringLength(25)]
    public string? Nama {get; set;}
    [StringLength(100)]
    public string? Alamat {get; set;}
    [StringLength(12)]
    public string? NoHp {get; set;}
    [StringLength(25)]
    public string? Negara {get; set;}

    [ForeignKey("User")]
    public int IdUser {get; set;}

    public virtual User? User {get; set;}
    public virtual ICollection<Barang>? Barangs {get; set;}
    // ICollection "Relasi many to many"
}