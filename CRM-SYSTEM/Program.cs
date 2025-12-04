using CRM_SYSTEM.Data;
using CRM_SYSTEM.Repositories;
using CRM_SYSTEM.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders(); 
builder.Logging.AddSerilog();    

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IClientsService, ClientsService>()
                .AddScoped<IClientsRepository, ClientsRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "db.db");

Log.Logger = new LoggerConfiguration()
    .WriteTo.SQLite(dbPath, tableName: "Logs")
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
