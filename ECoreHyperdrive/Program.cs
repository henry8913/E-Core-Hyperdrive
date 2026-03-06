using ECoreHyperdrive.Data;
using ECoreHyperdrive.Client.Pages;
using ECoreHyperdrive.Components;
using ECoreHyperdrive.Services;
using Microsoft.EntityFrameworkCore;
using ECoreHyperdrive.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<CarService>(); 
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=supercars.db"));
// -------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ECoreHyperdrive.Client._Imports).Assembly);

/* // --- SEEDING DEL DATABASE ---
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Se non ci sono auto nel database, aggiungile
    if (!context.Supercars.Any())
    {
        context.Supercars.AddRange(
            new Supercar { 
                Brand = "McMurtry Automotive", 
                Model = "McMurtry Spéirling Pure", 
                ZeroToHundred = 1.4, 
                RangeKm = 26, 
                Price = 995000, 
                ImageUrl = "https://cdn.motor1.com/images/mgl/g4k2w4/s3/mcmurtry-speirling-pure.jpg" 
            },
            new Supercar { 
                Brand = "Hispano Suiza", 
                Model = "Hispano Suiza Carmen Sagrera", 
                ZeroToHundred = 2.6, 
                RangeKm = 490, 
                Price = 3000000, 
                ImageUrl = "https://www.hispanosuizacars.com/assets/themes/hispano-suiza/_/img/tmp/carmen-sagrera-gallery/exterior/01_carmen_sagrera_exterior.jpg" 
            },
            new Supercar { 
                Brand = "Ariel", 
                Model = "Ariel Hipercar", 
                ZeroToHundred = 2.09, 
                RangeKm = 240, 
                Price = 840000, 
                ImageUrl = "https://www.ansa.it/webimages/news_base/2022/9/2/196e6466c66cb078516b491b0063cabb.jpg" 
            },
            new Supercar { 
                Brand = "BYD", 
                Model = "BYD Yangwang U9", 
                ZeroToHundred = 2.36, 
                RangeKm = 460, 
                Price = 400000, 
                ImageUrl = "https://media.motorbox.com/image/byd-yangwang-u9-un-design-audace-e-super-affilato/8/1/0/810041/810041-16x9-lg.jpg" 
            }
        );
        context.SaveChanges();
    }
}
// ---------------------------- */

app.Run();
