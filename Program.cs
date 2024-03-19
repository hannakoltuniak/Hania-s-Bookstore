using HaniasBookstore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGenre, GenreRepository>();
builder.Services.AddScoped<IBook, BookRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews(); //adding framework services which enables MVC in app
builder.Services.AddDbContext<HaniasBookstoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:HaniasBookstoreDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.MapDefaultControllerRoute(); //enables app to handle incoming requests

DbInitializer.Seed(app);

app.Run();
