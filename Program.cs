using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Registrar DbContext para Tickets
builder.Services.AddDbContext<apiwithdb.Data.AppDbContextTickets>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Registrar servicios y repositorios de Ticket
builder.Services.AddScoped<apiwithdb.Services.ITicketService, apiwithdb.Services.TicketService>();
builder.Services.AddScoped<apiwithdb.Repositories.ITicketRepository, apiwithdb.Repositories.TicketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
