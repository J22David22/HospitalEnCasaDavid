using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearEnfermeraModel : PageModel
    
    {
        private static IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Enfermera enfermera {get; set;}

        public CrearEnfermeraModel()
        {}

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                
                Enfermera enfermeraAdicionado = _repositorioEnfermera.AddEnfermera(enfermera);
                return RedirectToPage("../Auxiliares/AdminAuxEnfermera");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
