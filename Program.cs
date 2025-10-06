
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//scoped solo para db externo y singleton para db en memoria
builder.Services.AddScoped<apiwithdb.Services.IBookService, apiwithdb.Services.BookService>();
builder.Services.AddScoped<apiwithdb.Repositories.IBookRepository, apiwithdb.Repositories.BookRepository>();

builder.Services.AddDbContext<apiwithdb.Data.AppDbContextGuests>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<apiwithdb.Services.IGuestService, apiwithdb.Services.GuestService>();
builder.Services.AddScoped<apiwithdb.Repositories.IGuestRepository, apiwithdb.Repositories.GuestRepository>();
var app = builder.Build();
// Dependency Injection


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
