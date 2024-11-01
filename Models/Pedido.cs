using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.PortableExecutable;

namespace AMorfar_MVC.Models
{
    public class Pedido
    {
        //Anotation: Característica que se incorporan en los atributos para determinar las caracteristica de esos atributos.Su sintaxis va entre corchetes y encima del atributo al que se le coloca.EJ: MaxLenght: determinará la cant de caracteres que se puedenl almacenar en dicho atributo.
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Serán Anotation para ID_PEDIDO. Key = Primaria, por lo tanto, NO puede recibir nulo | DatabaseGenerated(DatabaseGeneratedOption.Identity: será autoEnumerada, un autoEnumerado es un ID de Pedido que cuenta automáticamente
        public int Id { get; set; }
        public double Total { get; set; }
        public double Propina { get; set; }         
        public List<Comanda>? Comandas { get; set; }

    }
}
