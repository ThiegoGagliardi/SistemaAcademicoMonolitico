using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Data.Configuration;

public class GradeHorariaConfiguration : IEntityTypeConfiguration<GradeHoraria>
{
    public void Configure(EntityTypeBuilder<GradeHoraria> builder)
    {
       builder.ToTable("Grade_Horaria");

       builder.HasKey(gh => new {gh.CursoId, gh.DisciplinaId, gh.ProfessorId});

       builder.Property(gh => gh.Dia)
              .HasMaxLength(100);

        builder.Property(gh => gh.HoraInicio)
               .HasColumnName("Hora_Inicio")
               .HasColumnType("time")
               .IsRequired();

        builder.Property(gh => gh.HoraFim)
               .HasColumnName("Hora_Fim")
               .HasColumnType("time")
               .IsRequired();

        builder.Property(gh => gh.Duracao)
               .HasColumnName("Duracao")
               .HasColumnType("time")
               .IsRequired();                              

        builder.HasOne(gh =>gh.Curso)
               .WithMany(c => c.Horarios)
               .HasForeignKey(cs => cs.CursoId)
               .OnDelete(DeleteBehavior.Restrict);                

        builder.HasOne(gh => gh.Disciplina)
               .WithMany(d => d.Horarios)
               .HasForeignKey(cs => cs.DisciplinaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gh => gh.Professor)
               .WithMany(p => p.Horarios)
               .HasForeignKey(gh => gh.ProfessorId)
               .OnDelete(DeleteBehavior.Restrict);                            
    }

}