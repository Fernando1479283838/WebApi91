using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyecciones de dependencias
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IAutorService, AutorService>();

builder.Services.AddTransient<IGastoService, GastoService>();

//Agregar el corsPolicy
builder.Services.AddCors(policyBulder =>
    policyBulder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);

var app = builder.Build();
app.UseCors();

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
