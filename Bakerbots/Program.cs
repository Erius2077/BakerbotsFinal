using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bakerbots.Data;
using Bakerbots.Configuration;
using Bakerbots.CommandHandler;
using Bakerbots.Commands;
using Bakerbots.QueryHandler;
using Bakerbots.DTOs;
using Bakerbots.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandHandler<Product>, UpdateProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<ProductDTO>, AddProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveByIdCommand>, RemoveProductCommandHandler>();
builder.Services.AddScoped<IQueryHandler<Product, QueryByIdCommand>, ProductQueryHandler>();
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