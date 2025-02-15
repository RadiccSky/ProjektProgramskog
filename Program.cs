using Microsoft.EntityFrameworkCore;
using ProjektProgramskog.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Dodaj CORS politiku
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")  // URL tvoje frontend aplikacije
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllersWithViews();  // Za MVC aplikaciju
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodaj DbContext
builder.Services.AddDbContext<Pi05Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Primijeni CORS politiku
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WeddingDetails}/{action=Index}/{id?}");

app.Run();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true; // Opcionalno
       
    });
