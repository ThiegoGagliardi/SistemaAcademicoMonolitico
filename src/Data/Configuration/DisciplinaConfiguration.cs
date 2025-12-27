using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Data.Configuration;

public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
{
    public void Configure(EntityTypeBuilder<Disciplina> builder)
    {
        builder.ToTable("Disciplinas");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.Codigo)         
               .HasMaxLength(100);

        builder.Property(d => d.Sigla)
               .HasMaxLength(10)
               .HasDefaultValue("");

        builder.Property(d => d.AreaConhecimento)
               .HasColumnName("Area_Conhecimento")
               .IsRequired()               
               .HasMaxLength(100); 

        builder.HasMany(d => d.Formacoes)
               .WithMany(f => f.Disciplinas)
               .UsingEntity(j => j.ToTable("DisciplinasFormacoes"));
                                     
    }
}