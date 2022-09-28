using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarDiagnosticoModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioDiagnostico _repoDiagnostico = new RepositorioDiagnostico (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public Diagnostico diagnostico {get;set;}

        // Constructor

        public EliminarDiagnosticoModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            diagnostico=_repoDiagnostico.GetDiagnostico(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                int idpacientes = _repoDiagnostico.GetDiagnostico(id).PacienteId;
                _repoDiagnostico.DeleteDiagnostico(id);
                Console.WriteLine("Eliminado correctamente");
                Console.WriteLine("Eliminado correctamente"+id);
                Console.WriteLine("Eliminado correctamente"+idpacientes);
                return Redirect("./ListadoHistorias?id="+idpacientes);
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
