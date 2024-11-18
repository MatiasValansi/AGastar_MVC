namespace AMorfar_MVC.Models
{
    public class ComandasPersonas
    {
        public int IdComanda { get; set; }
        public Comanda Comanda { get; set; }

        public int IdPersona { get; set; }
        public Persona Persona { get; set; }

    }
}
