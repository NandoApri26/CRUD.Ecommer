using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommer.Models.Entities;

public class Karyawan {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int IdKaryawan {get; set;}

    [StringLength(50)]
    public string? NamaKaryawan {get; set;}

    [StringLength(30)]
    public string? Username {get; set;}

    [StringLength(25)]
    public string? Password {get; set;}
    
    [StringLength(25)]
    public string? Posisi {get; set;}
}