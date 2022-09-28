using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearAuxiliarModel : PageModel
    
    {
        private static IRepositorioAuxiliar _repositorioAuxiliar = new RepositorioAuxiliar( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Auxiliar auxiliar {get; set;}

        public CrearAuxiliarModel()
        {}

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                
                Auxiliar auxiliarAdicionado = _repositorioAuxiliar.AddAuxiliar(auxiliar);
                return RedirectToPage("./AdminAuxiliar");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
