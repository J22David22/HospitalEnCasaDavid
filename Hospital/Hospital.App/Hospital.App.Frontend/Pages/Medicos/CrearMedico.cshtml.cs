using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearMedicoModel : PageModel
    
    {
        private static IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Medico medico {get; set;}

        public CrearMedicoModel()
        {}

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                
                Medico medicoAdicionado = _repositorioMedico.AddMedico(medico);
                return RedirectToPage("../Auxiliares/AdminAuxMedico");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
