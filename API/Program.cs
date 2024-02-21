using Abstracciones.DA;
using Abstracciones.BW;
using Abstracciones.DA;
using BW;
using DA;
using DA.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();

builder.Services.AddScoped<IUsuariosDA, UsuariosDA>();
builder.Services.AddScoped<IUsuariosBW, UsuariosBW>();
builder.Services.AddScoped<ITareasBW, TareasBW>();
builder.Services.AddScoped<ITareasDA, TareasDA>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
