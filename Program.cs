using Hania_s_Bookstore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //adding framework services which enables MVC in app

builder.Services.AddScoped<IGenre, MockupCategory>();
builder.Services.AddScoped<IBook, MockupBook>();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.MapDefaultControllerRoute(); //enables app to handle incoming requests

app.Run();
