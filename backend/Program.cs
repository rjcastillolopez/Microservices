using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using backend.Models;
using backend.DataService;
using backend.BusinessService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Database Context Dependency Injection
string dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
string dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "TestInnovar";
string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "sa";
string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "P@ssw0rd";

// Connection string for MS SQL Server
var connectionString = $"Server={dbHost};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=True";

builder.Services.AddDbContext<Context>(opt =>
    opt.UseSqlServer(connectionString)
);

builder.Services.AddTransient<StudentDataService>();
builder.Services.AddTransient<ScoreDataService>();
builder.Services.AddTransient<CourseDataService>();
builder.Services.AddTransient<StudentBusinessService>();
builder.Services.AddTransient<ScoreBusinessService>();
builder.Services.AddTransient<CourseBusinessService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
