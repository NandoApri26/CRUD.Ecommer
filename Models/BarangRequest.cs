namespace Ecommer.Models;
public class BarangRequest {
    public int Id {get; set;}
    public string? Kode {get; set;}
    public string? Nama {get; set;}
    public string? Description {get; set;}
    public decimal Harga {get; set;}
    public int Stok {get; set;}
    public string? Url {get; set;}
    public IFormFile? Image{get; set;}
    // Mengirimkan data dari view melalui IForm
}