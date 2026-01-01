using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Data.Configuration;

public class AlunoCursoDisciplinaNotaConfiguration : IEntityTypeConfiguration<AlunoCursoDisciplinaNota>
{
    public void Configure(EntityTypeBuilder<AlunoCursoDisciplinaNota> builder)
    {
        builder.ToTable("Aluno_Curso_Discplina_Nota");

        builder.HasKey(ac => new {ac.AlunoId, ac.DisciplinaId, ac.CursoId, ac.Bimestre});

        builder.Property(ac => ac.Nota)
               .HasColumnType("Decimal(10,2)");

        builder.Property(ac => ac.Bimestre)
               .HasColumnType("varchar");

        builder.Property(ac => ac.Peso)
               .HasColumnType("INT");

        builder.Property(ac => ac.Data)
               .IsRequired()
               .HasColumnType("Date");

        builder.HasOne(ac => ac.Aluno)
               .WithMany(a => a.Notas)
               .HasForeignKey(ac => ac.AlunoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ac => ac.Curso)
               .WithMany()
               .HasForeignKey(ac => ac.CursoId)
               .OnDelete(DeleteBehavior.Restrict);
    
        builder.HasOne(ac => ac.Disciplina)
               .WithMany()
               .HasForeignKey(ac => ac.DisciplinaId)
               .OnDelete(DeleteBehavior.Restrict);    
    }
}