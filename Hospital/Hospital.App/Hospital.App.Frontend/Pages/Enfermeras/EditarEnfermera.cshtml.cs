using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarEnfermeraModel : PageModel
   {
        private static IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Enfermera enfermera {get; set;}

        public ActionResult OnGet(int id)
        {
            this.enfermera = _repositorioEnfermera.GetEnfermera(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                Enfermera enfermeraActualizado = _repositorioEnfermera.UpdateEnfermera(enfermera);
                return RedirectToPage("../Auxiliares/AdminAuxEnfermera");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
