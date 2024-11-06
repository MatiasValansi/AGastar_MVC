using AMorfar_MVC.Models;

namespace AMorfar_MVC.Helpers
{
    public class Helper
    {
        // metodo generico para guardar en cualquier entidad. Cada controller instancia su contexto, arma su objeto y se lo manda.
        // este buen tipo viene y guarda lo que sea (obj) en donde sea (context). Maneja trycatch
        // obj = objeto. Tambien del tipo objeto porque no sabemos si ibe un pedido, un producto, una persona, etc. Podemos usar generics.
        public static Response Guardar(Context context, object obj)
        {
            string message;
            bool status = true;
            try
            {
                context.Add(obj);
                context.SaveChanges();
                message = "guardado de forma exitosa";
            }catch(Exception e)
            {
                status = false;
                message = e.Message;
            }
            return new Response(status, message);

        }
    }
}
