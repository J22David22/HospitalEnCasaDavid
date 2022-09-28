using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarEnfermeraModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioEnfermera _repoEnfermera = new RepositorioEnfermera (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public Enfermera enfermera {get;set;}

        // Constructor

        public EliminarEnfermeraModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            this.enfermera=_repoEnfermera.GetEnfermera(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                _repoEnfermera.DeleteEnfermera(id);
                return RedirectToPage("../Auxiliares/AdminAuxEnfermera");
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
