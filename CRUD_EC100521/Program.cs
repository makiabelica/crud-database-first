using CRUD_EC100521.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CrudContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

// Add authorization services
builder.Services.AddAuthorization();

// Add controllers (and views if needed)
builder.Services.AddControllersWithViews(); // O solo AddControllers() si solo estás usando APIs

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
