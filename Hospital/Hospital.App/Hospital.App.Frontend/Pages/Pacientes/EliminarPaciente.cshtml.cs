using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarPacienteModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente (new Hospital.App.Persistencia.AppContext());
        
        // Creamos variable para mapear que llega el usuario desde la base de datos

        public Paciente paciente {get;set;}

        // Constructor

        public EliminarPacienteModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            this.paciente=_repoPaciente.GetPaciente(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                _repoPaciente.DeletePaciente(id);
                return RedirectToPage("../Auxiliares/AdminAuxPaciente");
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
