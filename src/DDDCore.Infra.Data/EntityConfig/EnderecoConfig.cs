using DDDCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDCore.Infra.Data.EntityConfig
{
    public class EnderecoConfig
    {
        public EnderecoConfig(EntityTypeBuilder<Endereco> entityBuilder)
        {
            entityBuilder.HasKey(e => e.EnderecoId);

            entityBuilder.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            entityBuilder.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8);

            entityBuilder.Property(e => e.Complemento)
                .HasMaxLength(100);

            entityBuilder.ToTable("Enderecos");

        }
    }
}