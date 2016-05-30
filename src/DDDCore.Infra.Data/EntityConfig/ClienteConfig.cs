using DDDCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDCore.Infra.Data.EntityConfig
{
    public class ClienteConfig 
    {
        public ClienteConfig(EntityTypeBuilder<Cliente> entityBuilder)
        {
            entityBuilder.HasKey(c => c.ClienteId);

            entityBuilder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            entityBuilder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);
                //.HasAnnotation("Index", (new IndexAttribute() { IsUnique = true }));

            entityBuilder.Property(c => c.DataNascimento)
              .IsRequired();

            entityBuilder.Property(c => c.Ativo)
                .IsRequired();

            //Ignore(c => c.ValidationResult);

            entityBuilder.ToTable("Clientes");

        }
    }
}