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
// app.UseHttpsRedirection(); // Disabilitato per semplificare il deploy Docker

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ECoreHyperdrive.Client._Imports).Assembly);

// --- SEEDING DEL DATABASE ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try 
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated(); // Assicura che il DB esista

        // Lista completa delle 10 Hypercar
        var cars = new List<Supercar>
    {
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
        },
        new Supercar {
            Brand = "Lamborghini",
            Model = "Lanzador",
            ZeroToHundred = 2.5,
            RangeKm = 480,
            Price = 300000,
            ImageUrl = "https://img.motori.it/fjEQa_mhRl7r4I8p1BhpGpUaqg4=/780x420/filters:quality(100):format(webp)/www.motori.it/app/uploads/2023/08/lamborghini-lanzador-44.jpg"
        },
        new Supercar {
            Brand = "NIO",
            Model = "EP9",
            ZeroToHundred = 2.7,
            RangeKm = 427,
            Price = 1480000,
            ImageUrl = "https://statics.quattroruote.it/content/dam/quattroruote/it/news/novita/2016/11/21/nio_ep9_nextev_svela_l_hypercar_elettrica_da_1_360_cv/gallery/rbig/2016-nio5.jpg"
        },
        new Supercar {
            Brand = "Rimac",
            Model = "Nevera",
            ZeroToHundred = 1.81,
            RangeKm = 490,
            Price = 2000000,
            ImageUrl = "https://img.stcrm.it/images/25037453/800x/20210603-150823286-4294.jpg"
        },
        new Supercar {
            Brand = "Automobili Pininfarina",
            Model = "Battista",
            ZeroToHundred = 1.86,
            RangeKm = 476,
            Price = 2200000,
            ImageUrl = "https://zmfqrnenekgkedngmqke.supabase.co/storage/v1/object/public/media/automobili-pininfarina/anniversario_05.jpg"
        },
        new Supercar {
            Brand = "Lotus",
            Model = "Evija",
            ZeroToHundred = 2.9,
            RangeKm = 400,
            Price = 2300000,
            ImageUrl = "https://espirituracer.com/archivos/2020/08/lotus-evija-1.jpg"
        },
        new Supercar {
            Brand = "Aspark",
            Model = "Owl",
            ZeroToHundred = 1.69,
            RangeKm = 450,
            Price = 2900000,
            ImageUrl = "https://static0.carbuzzimages.com/wordpress/wp-content/uploads/2025/09/aspark-owl-roadster-front-quarter.jpg"
        }
    };

    foreach (var car in cars)
    {
        if (!context.Supercars.Any(c => c.Model == car.Model))
        {
            context.Supercars.Add(car);
        }
    }
    
    context.SaveChanges();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
// ----------------------------

app.Run();
