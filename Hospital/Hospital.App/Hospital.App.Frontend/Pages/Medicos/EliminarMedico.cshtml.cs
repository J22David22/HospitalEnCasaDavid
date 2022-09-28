using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarMedicoModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioMedico _repoMedico = new RepositorioMedico (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public Medico medico {get;set;}

        // Constructor

        public EliminarMedicoModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            this.medico=_repoMedico.GetMedico(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                _repoMedico.DeleteMedico(id);
                return RedirectToPage("../Auxiliares/AdminAuxMedico");
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
