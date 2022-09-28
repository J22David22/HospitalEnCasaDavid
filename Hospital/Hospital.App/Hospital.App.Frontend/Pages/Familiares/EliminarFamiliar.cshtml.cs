using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarFamiliarModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioFamiliar _repoFamiliar = new RepositorioFamiliar (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public Familiar familiar {get;set;}

        // Constructor

        public EliminarFamiliarModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            this.familiar=_repoFamiliar.GetFamiliar(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                _repoFamiliar.DeleteFamiliar(id);
                return RedirectToPage("../Auxiliares/AdminAuxFmliar");
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
