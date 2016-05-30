using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DDDCore.Infra.Data.Context;

namespace DDDCore.Application.Migrations
{
    [DbContext(typeof(DDDContext))]
    [Migration("20160526200119_MigrationCore")]
    partial class MigrationCore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDDCore.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 11);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DDDCore.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("EnderecoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 8);

                    b.Property<string>("Cidade");

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Complemento")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("EnderecoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("DDDCore.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("DDDCore.Domain.Entities.Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
