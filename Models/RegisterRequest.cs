namespace Ecommer.Models;

public class RegisterRequest {
    public string? Username {get; set;}
    public string? Password {get; set;}
    public string Tipe { get; set; } = null!;
}