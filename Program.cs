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

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers().AddJsonOptions(x => {
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

string connectionString = "Server=sqlserver-db,1433;Database=SistemaAcademicoBD;User Id=sa;Password=S3nh@Academi.c0;TrustServerCertificate=True";

var dockerConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (!string.IsNullOrEmpty(dockerConnectionString))
{
    connectionString = dockerConnectionString;
}

builder.Services.AddDbContext<SistemaAcademicoDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IFormacaoRepository, FormacaoRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
builder.Services.AddScoped<IAtribuicaoAulaRepository, AtribuicaoAulaRepository>();
builder.Services.AddScoped<INotasAlunoRepository,NotasAlunoRepository>();

builder.Services.AddScoped<IProfessorFactory, ProfessorFactory>();
builder.Services.AddScoped<IAlunoFactory, AlunoFactory>();
builder.Services.AddScoped<ICursoFactory, CursoFactory>();
builder.Services.AddScoped<IDisciplinaFactory, DisciplinaFactory>();
builder.Services.AddScoped<IFormacaoFactory, FormacaoFactory>();
builder.Services.AddScoped<IGradeHorariaFactory, GradeHorariaFactory>();
builder.Services.AddScoped<IHorarioFactory, HorarioFactory>();
builder.Services.AddScoped<INotasAlunoFactory,NotasAlunoFactory>();


builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IFormacaoService, FormacaoService>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IAtribuicaoAulaService, AtribuicaoAulaService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<INotasAlunoService, NotasAlunoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
