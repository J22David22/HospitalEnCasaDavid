using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarMedicoModel : PageModel
   {
        private static IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Medico medico {get; set;}

        public ActionResult OnGet(int id)
        {
            this.medico = _repositorioMedico.GetMedico(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                Medico medicoActualizado = _repositorioMedico.UpdateMedico(medico);
                return RedirectToPage("../Auxiliares/AdminAuxMedico");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
