using BitsOrch.ApplicationCore.Interfaces;
using BitsOrch.ApplicationCore.Repositories;
using BitsOrch.ApplicationCore.Services;
using BitsOrch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration["DBConnectionString"];
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString , b => b.MigrationsAssembly("BitsOrch.Infrastructure")));

//DI
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileService, FileService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();