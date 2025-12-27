using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Data.Configuration;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{

    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.ToTable("Professores");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.DataContratacao)
               .IsRequired();

        builder.Property(p => p.RegistroMec)
               .IsRequired()               
               .HasMaxLength(100);

        builder.Property(p => p.Pontuacao)
               .HasColumnType("decimal(12,4)")
               .HasDefaultValue(0);
    }
}