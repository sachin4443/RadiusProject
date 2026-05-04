using Microsoft.EntityFrameworkCore;
using Radius.API.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧱 Add Controllers
builder.Services.AddControllers();

// 🌐 CORS (React frontend ke liye IMPORTANT)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// 📄 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ⚙️ Middleware Pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🌐 Enable CORS
app.UseCors("AllowAll");

// 🔐 (future me JWT aayega yaha)
app.UseAuthorization();

// 📡 Map Controllers
app.MapControllers();

app.Run();