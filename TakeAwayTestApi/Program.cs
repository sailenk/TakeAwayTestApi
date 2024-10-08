using TakeAwayTestApi.Presistance;
using TakeAwayTestApi.Presistance.Models;
using TakeAwayTestApi.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ITakeAwayTestService, TakeAwayTestSerivce>();
builder.Services.AddScoped<ITakeAwayTestRepository, TakeAwayTestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

{
    await app.InitDatabase();
}

app.MapControllers();
app.Run();