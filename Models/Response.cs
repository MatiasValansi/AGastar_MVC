namespace AMorfar_MVC.Models
{
    // clase creada como buena practica. Todos los llamados van a devolver a este mismo tipo, varian sus valores de atributos
    public class Response(bool _status, string _message)
    {
        public string Message { get; set; } = _message;
        public bool Status { get; set; } = _status;
    }
}
