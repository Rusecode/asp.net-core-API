using Microsoft.EntityFrameworkCore;
using BlogUser.Models;

namespace BlogUser.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações do modelo
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id); // Definindo a chave primária

            // Se houver restrições ou configurações adicionais, adicione aqui
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome)
                .IsRequired() // Exige que o Nome não seja nulo
                .HasMaxLength(100); // Define um tamanho máximo para o Nome
        }
    }
}



