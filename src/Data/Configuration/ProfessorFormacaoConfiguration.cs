using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Data.Configuration;

public class ProfessorFormacaoConfiguration : IEntityTypeConfiguration<ProfessorFormacao>
{
    public void Configure(EntityTypeBuilder<ProfessorFormacao> builder)
    {
        builder.ToTable("ProfessoresFormacoes");

        builder.HasKey(pf => new{pf.ProfessorId, pf.FormacaoId} );

        builder.Property(pf => pf.Inicio)
               .IsRequired()
               .HasColumnType("Date");

        builder.Property(pf => pf.Termino)
               .IsRequired()
               .HasColumnType("Date");

        builder.HasOne(pf => pf.Professor)
               .WithMany()
               .HasForeignKey(pf => pf.ProfessorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pf => pf.Formacao)
               .WithMany()
               .HasForeignKey(pf => pf.FormacaoId)
               .OnDelete(DeleteBehavior.Restrict);               
    }
}