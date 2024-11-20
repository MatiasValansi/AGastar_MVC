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
            //Fluent API
            //Relaciones del UML;
            modelBuilder.Entity<Comanda>()   //La Comanda tiene:            
                .HasOne(comanda => comanda.Pedido) //Se especifica con cual otra clase (o Entidad) tiene relación la clase Comanda.
                .WithMany(pedido => pedido.Comandas) //La cardinalidad del UML entre Comanda y Pedido: en el UML se ve que Pedidos tiene de una a muchas (1...n) Comandas
                .HasForeignKey(comanda => comanda.PedidoActual) //La Clave Foranea: es un atributo 
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ComandasPersonas>()
                .HasKey(cp => new { cp.IdPersona, cp.IdComanda });

            modelBuilder.Entity<Persona>()
                .HasOne(persona => persona.Pedido)
                .WithMany(pedido => pedido.Personas)
                .HasForeignKey(persona => persona.PedidoActual)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
