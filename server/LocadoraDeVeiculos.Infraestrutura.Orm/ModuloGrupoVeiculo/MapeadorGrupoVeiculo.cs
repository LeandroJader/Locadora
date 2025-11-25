using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infraestrutura.Orm.ModuloGrupoVeiculo
{
    internal class MapeadorGrupoVeiculo : IEntityTypeConfiguration<GrupoDeVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoDeVeiculos> builder)
        {
         
            builder.ToTable("GruposDeVeiculos");

            // Chave primária
            builder.HasKey(g => g.Id);

    
            builder.Property(g => g.Nome)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
