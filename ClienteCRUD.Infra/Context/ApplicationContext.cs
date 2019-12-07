using ClienteCRUD.Domain.Entities.Mapeamento;
using ClienteCRUD.Infra.DBConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClienteCRUD.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("SqlExpressConnection"));

            }
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        public virtual DbSet<Cliente> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.CPF)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(true);

                entity.Property(e => e.Nome)
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoId)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasIndex(e => e.Id)
                 .IsUnique();

                entity.Property(e => e.Logradouro)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                  .IsRequired()
                  .HasMaxLength(40)
                  .IsUnicode(false);

                entity.Property(e => e.Estado)
                  .IsRequired()
                  .HasMaxLength(40)
                  .IsUnicode(false);
            });
        }
    }
}
