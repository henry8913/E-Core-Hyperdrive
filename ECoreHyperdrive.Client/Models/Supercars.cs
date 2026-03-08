namespace ECoreHyperdrive.Models;

public class Supercar
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    
    // Lo 0-100 è un numero decimale (es: 1.9)
    public double ZeroToHundred { get; set; }
    
    // L'autonomia in km
    public int RangeKm { get; set; }
    
    // Il prezzo
    public decimal Price { get; set; }
    
    // L'immagine (per ora mettiamo un link)
    public string? ImageUrl { get; set; }
}