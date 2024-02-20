using HaniasBookstore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGenre, GenreRepository>();
builder.Services.AddScoped<IBook, BookRepository>();

builder.Services.AddControllersWithViews(); //adding framework services which enables MVC in app
builder.Services.AddDbContext<HaniasBookstoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:HaniasBookstoreDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.MapDefaultControllerRoute(); //enables app to handle incoming requests

DbInitializer.Seed(app);

app.Run();
