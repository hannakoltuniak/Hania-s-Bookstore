using HaniasBookstore.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HaniasBookstoreDbContextConnection") ?? throw new InvalidOperationException("Connection string 'HaniasBookstoreDbContextConnection' not found.");

builder.Services.AddDbContext<HaniasBookstoreDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<HaniasBookstoreDbContext>();

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


var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.MapDefaultControllerRoute(); //enables app to handle incoming requests
app.MapRazorPages();

DbInitializer.Seed(app);

app.Run();
