using AMorfar_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace AMorfar_MVC.Contexts
{
    public class MockContext
    {
                

        public static readonly MockContext getInstance = new();


        public List<Pedido> Pedidos { get; set; } = new();
        public List<Persona> Personas { get; set; } = new();

        public List<Comanda> Comandas { get; set; } = new();
        public List<ComandasPersonas> ComandasPersonas { get; set; } = new();


        // PEDIDO
        public void AddPedido(Pedido pedido)
        {
            pedido.PedidoId = Pedidos.Count + 1;
            Pedidos.Add(pedido);
        }

        public void RemovePedido(int id)
        {
            Pedidos.RemoveAll(p => p.PedidoId == id);
            Personas.RemoveAll(p => p.PedidoActual == id);
        }

        public Pedido? GetPedido(int id)
        {
            var pedido = Pedidos.FirstOrDefault(p => p.PedidoId == id);
            if (pedido != null)
            {
                pedido.Personas = Personas.Where(p => p.PedidoActual == id).ToList();
            }
            return pedido;
        }

        public void EditarPedido(Pedido pedido)
        {
            var pedidoExistente = Pedidos.FirstOrDefault(p => p.PedidoId == pedido.PedidoId);
            if (pedidoExistente != null)
            {
                pedidoExistente.Titulo = pedido.Titulo;
                pedidoExistente.Propina = pedido.Propina;
                pedidoExistente.Activo = pedido.Activo;
                pedidoExistente.Fecha = pedido.Fecha;
            }
        }

        // PERSONA
        public void AddPersona(Persona persona)
        {
            persona.PersonaId = Personas.Count + 1;
            Personas.Add(persona);
        }

        public void RemovePersona(int id)
        {
            Personas.RemoveAll(p => p.PersonaId == id);
        }

        public void EditarPersona(Persona persona)
        {
            var personaExistente = Personas.FirstOrDefault(p => p.PersonaId == persona.PersonaId);
            if (personaExistente != null)
            {
                personaExistente.Nombre = persona.Nombre;
                personaExistente.PedidoActual = persona.PedidoActual;
            }
        }

        // COMANDA
        public void AddComanda(Comanda comanda)
        {
            comanda.ComandaId = Comandas.Count + 1;
            Comandas.Add(comanda);
        }

        public void RemoveComanda(int id)
        {
            Comandas.RemoveAll(c => c.ComandaId == id);
            ComandasPersonas.RemoveAll(cp => cp.IdComanda == id);
        }

        // COMANDASPERSONAS
        public void AddComandasPersonas(ComandasPersonas cp)
        {
            ComandasPersonas.Add(cp);
        }

        public void RemoveComandasPersonas(int comandaId, int personaId)
        {
            ComandasPersonas.RemoveAll(cp => cp.IdComanda == comandaId && cp.IdPersona == personaId);
        }
    }
}
