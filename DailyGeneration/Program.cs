using Application.Apps;
using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<TodoDbContext>(option =>
{
    option.UseSqlServer("server=.;database=Todo;user id=laiwang;password=123123;TrustServerCertificate=true;");
});

builder.Services.AddScoped<TodoRepository>();

builder.Services.AddScoped<TodoApplication>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
