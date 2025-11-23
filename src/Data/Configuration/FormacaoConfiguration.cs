using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Data.Configuration;

public class FormacaoConfiguration : IEntityTypeConfiguration<Formacao>
{
    public void Configure(EntityTypeBuilder<Formacao> builder)
    {
        builder.ToTable("Formacoes");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.Instituicao)
               .IsRequired()
               .HasMaxLength(100);
                              
        builder.Property(f => f.Nivel)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.ValorPontuacao)
               .HasColumnName("Valor_Pontuacao")
               .HasColumnType("decimal(12,4)")
               .IsRequired();

        builder.Property(f => f.AreaConhecimento)
               .HasColumnName("Area_Conhecimento")
               .IsRequired()
               .HasMaxLength(100);              
    }
}