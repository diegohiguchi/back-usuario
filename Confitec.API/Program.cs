using Confitec.API.Filters;
using Confitec.Application.Commands.CriarUsuario;
using Confitec.Application.Validators;
using Confitec.Core.Repositories;
using Confitec.Infrastructure.Persistence;
using Confitec.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConfitecCs");
builder.Services.AddDbContext<ConfitecDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
builder.Services.AddScoped<IHistoricoEscolarRepository, HistoricoEscolarRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CriarUsuarioCommandValidator>())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EditarUsuarioCommandValidator>());

builder.Services.AddMediatR(typeof(CriarUsuarioCommand));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
