using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Data.Configuration;

public class CursoDisciplinaConfiguration : IEntityTypeConfiguration<CursoDisciplina>
{

    public void Configure (EntityTypeBuilder<CursoDisciplina> builder)
    {
        builder.ToTable("Cursos_Disciplinas");

        builder.HasKey(cs => new {cs.CursoId, cs.DisciplinaId});

        builder.Property(cs => cs.Ementa)
               .HasMaxLength(100);

        builder.Property(cs => cs.CargaHoraria)
               .HasColumnName("Carga_Horaria")
               .HasColumnType("int")
               .HasMaxLength(100);

        builder.Property(cs => cs.Ativo)
               .HasColumnName("Ativo")
               .HasColumnType("bit");

        builder.HasOne(cs =>cs.Curso)
               .WithMany(c => c.Disciplinas)
               .HasForeignKey(cs => cs.CursoId)
               .OnDelete(DeleteBehavior.Restrict);                

        builder.HasOne(cs => cs.Disciplina)
               .WithMany(d => d.Cursos)
               .HasForeignKey(cs => cs.DisciplinaId)
               .OnDelete(DeleteBehavior.Restrict);          
    }
}