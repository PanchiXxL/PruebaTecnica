using CreditosAPI.Interfaces;
using CreditosAPI.Services;
using Microsoft.EntityFrameworkCore;
using Sistema_Creditos.Model.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  INYECTAR CONEXION DE BDD
var con = builder.Configuration.GetConnectionString("ConectionSQL");
builder.Services.AddDbContext<CreditosContext>(option => option.UseSqlServer(con));

//  PATRONES
//builder.Services.AddScoped<IOperacionesService, OperacionService>();


//  CREACION DE CORS            
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddScoped<OperacionService>();
builder.Services.AddScoped<TipoCreditoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
