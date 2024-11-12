using GarageASP.NetMVC.Interfaces;
using GarageASP.NetMVC.Models;
using GarageASP.NetMVC.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GarageManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GMConnection")));
builder.Services.AddScoped<IGarageManagement, GarageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Voitures}/{action=Index}/{id?}");

app.Run();
