using ECoreHyperdrive.Data;
using ECoreHyperdrive.Models;
using Microsoft.EntityFrameworkCore;

namespace ECoreHyperdrive.Services;

public class CarService(IDbContextFactory<AppDbContext> factory)
{
    private readonly IDbContextFactory<AppDbContext> _factory = factory;

    public async Task<List<Supercar>> GetInventoryAsync()
    {
        using var context = await _factory.CreateDbContextAsync();
        return await context.Supercars.AsNoTracking().ToListAsync();
    }

    public async Task AddCarAsync(Supercar car)
    {
        using var context = await _factory.CreateDbContextAsync();
        context.Supercars.Add(car);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(int id)
    {
        using var context = await _factory.CreateDbContextAsync();
        var car = await context.Supercars.FindAsync(id);
        if (car != null)
        {
            context.Supercars.Remove(car);
            await context.SaveChangesAsync();
        }
    }

    public async Task UpdateCarAsync(Supercar car)
    {
        using var context = await _factory.CreateDbContextAsync();
        context.Supercars.Update(car);
        await context.SaveChangesAsync();
    }
}
