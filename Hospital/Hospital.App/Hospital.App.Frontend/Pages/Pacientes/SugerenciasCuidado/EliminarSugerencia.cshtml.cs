using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarSugerenciaModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioSugerenciasCuidado _repoSugerenciasCuidado = new RepositorioSugerenciasCuidado (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public SugerenciasCuidado sugerenciasCuidado {get;set;}

        // Constructor

        public EliminarSugerenciaModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            sugerenciasCuidado=_repoSugerenciasCuidado.GetSugerenciasCuidado(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                Console.WriteLine("diagid: " + id);
                sugerenciasCuidado = _repoSugerenciasCuidado.GetSugerenciasCuidado(id);
                Console.WriteLine("diagid: " + sugerenciasCuidado.DiagnosticoId);
                int direccion = sugerenciasCuidado.DiagnosticoId;
                Console.WriteLine("diagid: " + direccion);
                _repoSugerenciasCuidado.DeleteSugerenciasCuidado(id);
                return Redirect("./ListaSugerenciasCuidado?id="+direccion);
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
