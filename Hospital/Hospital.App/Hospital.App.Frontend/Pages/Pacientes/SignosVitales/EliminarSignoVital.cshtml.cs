using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarSignoVitalModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioSignoVital _repoSignoVital = new RepositorioSignoVital (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public SignoVital signoVital {get;set;}

        // Constructor

        public EliminarSignoVitalModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            this.signoVital=_repoSignoVital.GetSignoVital(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                signoVital = _repoSignoVital.GetSignoVital(id);
                int paci = signoVital.PacienteId;
                _repoSignoVital.DeleteSignoVital(id);
                Console.WriteLine("paci" + paci);
                return Redirect("./ListadoSignosVitales?id="+paci);
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
