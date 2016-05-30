using DDDCore.Domain.Entities;
using DDDCore.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace DDDCore.Infra.Data.Context
{
    public class DDDContext : DbContext
    {
        public DDDContext(DbContextOptions<DDDContext> options ) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            new ClienteConfig(modelBuilder.Entity<Cliente>());
            new EnderecoConfig(modelBuilder.Entity<Endereco>());

            modelBuilder.Entity<Endereco>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Enderecos)
                .IsRequired();

            //modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Properties()
            //    .Where((p => p.Name == p.ReflectedType.Name + "Id"))
            //    .Configure(p => p.IsKey());

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Configurations.Add(new ClienteConfig());
            //modelBuilder.Configurations.Add(new EnderecoConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}
