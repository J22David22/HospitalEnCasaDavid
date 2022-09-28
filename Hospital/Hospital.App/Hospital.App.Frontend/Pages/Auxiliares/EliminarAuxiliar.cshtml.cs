using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarAuxiliarModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioAuxiliar _repoAuxiliar = new RepositorioAuxiliar (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public Auxiliar auxiliar {get;set;}

        // Constructor

        public EliminarAuxiliarModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            this.auxiliar=_repoAuxiliar.GetAuxiliar(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                _repoAuxiliar.DeleteAuxiliar(id);
                return RedirectToPage("./AdminAuxiliar");
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
