using Microsoft.EntityFrameworkCore;

namespace AMorfar_MVC.Models
{
    public class Context:DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-BSH8LIC; Initial Catalog = AMorfar;" +
                " Encrypt=true;" +
                " TrustServerCertificate = true; Integrated Security = true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Comanda>()
                .HasOne<Pedido>(comanda => comanda.Pedido)
                .WithMany(pedido => pedido.Comandas)
                .HasForeignKey(comanda => comanda.PedidoActual);


        }

    }
}
