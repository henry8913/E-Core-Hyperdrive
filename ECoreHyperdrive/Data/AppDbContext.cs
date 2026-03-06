using Microsoft.EntityFrameworkCore;
using ECoreHyperdrive.Models;

namespace ECoreHyperdrive.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Crea una tabella chiamata Supercars basata sul modello Supercar
    public DbSet<Supercar> Supercars { get; set; }
}