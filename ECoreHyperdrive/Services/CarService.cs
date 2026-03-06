using ECoreHyperdrive.Data;
using ECoreHyperdrive.Models;
using Microsoft.EntityFrameworkCore;

namespace ECoreHyperdrive.Services;

public class CarService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<List<Supercar>> GetInventoryAsync()
    {
        return await _context.Supercars.ToListAsync();
    }

    public async Task AddCarAsync(Supercar car)
    {
        _context.Supercars.Add(car);
        await _context.SaveChangesAsync();
    }
}
