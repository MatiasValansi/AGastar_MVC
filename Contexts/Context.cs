using AMorfar_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AMorfar_MVC.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Reemplazar Data Soruce = NOMBRE_PC por . (un punto) o el nombre de mi PC.
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-BSH8LIC; Initial Catalog = AMorfar;" +
                " Encrypt=true;" +
                " TrustServerCertificate = true; Integrated Security = true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasOne(p=>p.Pedido)
                .WithMany(p => p.Personas)
                .HasForeignKey(p=>p.PedidoActual)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComandasPersonas>()
                .HasKey(cp => new { cp.IdPersona, cp.IdComanda });

        }

    }
}
