using Microsoft.EntityFrameworkCore;

namespace AMorfar_MVC.Models
{
    public class Context:DbContext
    {
        //Creamos una Tabla para cada Clase
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-N2PQ7KR\\SQLEXPRESS; Initial Catalog = AMorfar;" +
                " Encrypt=true;" +
                " TrustServerCertificate = true; Integrated Security = true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            //Cardinalidad entre las clases
            modelBuilder.Entity<Pedido>()
                .HasMany(pedido => pedido.comandas) //HasOne = Tiene una referencia (Cardinalidad = 1..n) --> Es el 1
                .WithOne(comanda => comanda.pedido)// WithMany = A muchos (Cardinalidad = 1..n) ---> Es el N
                .HasForeignKey(comanda => comanda.IdPedido);    

            modelBuilder.Entity<Venta>()
                .HasOne(ven => ven.VendedorVenta)
                .WithMany(ve => ve.Ventas)
                .HasForeignKey(ven => ven.VendedorId);

            modelBuilder.Entity<Venta>()
                .HasOne(ven => ven.ProductoVenta)
                .WithMany(p => p.Ventas)
                .HasForeignKey(ven => ven.ProductoId);
        }

    }
}
