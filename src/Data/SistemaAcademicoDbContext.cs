using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data.Configuration;

namespace SistemaAcademicoMonolitico.src.Data;

public class SistemaAcademicoDbContext : DbContext
{

    public DbSet<Professor> Professores { get; set; }

    public DbSet<Aluno> Alunos { get; set; }

    public DbSet<Curso> Cursos { get; set; }

    public DbSet<Disciplina> Disciplinas { get; set; }

    public DbSet<Formacao> Formacoes { get; set; }
    
    public DbSet<GradeHoraria> GradeHoraria { get; set; }

    public SistemaAcademicoDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProfessorConfiguration());
        builder.ApplyConfiguration(new DisciplinaConfiguration());
        builder.ApplyConfiguration(new CursoConfiguration());
        builder.ApplyConfiguration(new FormacaoConfiguration());
        builder.ApplyConfiguration(new AlunoConfiguration());

        builder.ApplyConfiguration(new ProfessorFormacaoConfiguration());
        builder.ApplyConfiguration(new CursoDisciplinaConfiguration());
        builder.ApplyConfiguration(new GradeHorariaConfiguration());
        builder.ApplyConfiguration(new MatriculaAlunoCursoConfiguration());
        builder.ApplyConfiguration(new AlunoCursoDisciplinaConfiguration());
    }
}