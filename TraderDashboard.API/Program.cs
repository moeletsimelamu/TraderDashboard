using Microsoft.EntityFrameworkCore;
using TraderDashboard.Application.Interfaces;
using TraderDashboard.Application.Services;
using TraderDashboard.Infrastructure.Data;
using TraderDashboard.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<IStrategyRepository, StrategyRepository>();
builder.Services.AddScoped<IUploadLogRepository, UploadLogRepository>();

// Services
builder.Services.AddScoped<TradeService>();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS — allow Angular dev server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// --- Middleware pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();