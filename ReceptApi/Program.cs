using Microsoft.EntityFrameworkCore;
using ReceptApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var kapcsolat = "Server=localhost;Port=3306;Database=receptes_app;User=root;Password=;";
builder.Services.AddDbContext<ReceptContext>(o => o.UseMySql(kapcsolat, ServerVersion.AutoDetect(kapcsolat)));

var app = builder.Build();

app.MapControllers();
app.Run("http://localhost:5000");