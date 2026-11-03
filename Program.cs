using Microsoft.EntityFrameworkCore;
using VMS_Hisham_El_Shiraida.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (OperatingSystem.IsWindows())
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")
            ?? "Data Source=VMS_Hisham_El-Shiraida.db");
    }
});

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
