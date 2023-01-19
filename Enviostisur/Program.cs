using Enviostisur.Data;
using Enviostisur.Helpers;
using Enviostisur.IService;
using Enviostisur.Provider;
using Enviostisur.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
//inyeccion de dependencias de interfaces y de su implementacion.
builder.Services.AddScoped<ITmrecaService, TmrecaService>();
builder.Services.AddScoped<ITcdocu_origService, TcdocuOrigService>();
builder.Services.AddScoped<ITddocu_origService, TddocuOrigService>();
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddSingleton<HelpersUpload>();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        o.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


    var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "Rotativa/Windows");

app.Run();
