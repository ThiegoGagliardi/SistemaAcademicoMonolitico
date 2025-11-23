using Microsoft.EntityFrameworkCore;
using System.Text;

using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Factories;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.src.Services;
using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.Domain.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

string connectionString = @"";

var dockerConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
if (!string.IsNullOrEmpty(dockerConnectionString))
{
    connectionString = dockerConnectionString;
}

builder.Services.AddDbContext<SistemaAcademicoDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

builder.Services.AddScoped<IProfessorFactory, ProfessorFactory>();
builder.Services.AddScoped<IAlunoFactory, AlunoFactory>();
builder.Services.AddScoped<ICursoFactory, CursoFactory>();
builder.Services.AddScoped<IDisciplinaFactory, DisciplinaFactory>();
builder.Services.AddScoped<IFormacaoFactory, FormacaoFactory>();
builder.Services.AddScoped<IGradeHorariaFactory, GradeHorariaFactory>();
builder.Services.AddScoped<IHorarioFactory, HorarioFactory>();

builder.Services.AddScoped<IProfessorService, ProfessorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
