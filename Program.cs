using HaniasBookstore.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGenre, GenreRepository>();
builder.Services.AddScoped<IBook, BookRepository>();
builder.Services.AddScoped<IOrder, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews().AddJsonOptions(options => 
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); 
builder.Services.AddRazorPages();
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
app.MapRazorPages();

DbInitializer.Seed(app);

app.Run();
