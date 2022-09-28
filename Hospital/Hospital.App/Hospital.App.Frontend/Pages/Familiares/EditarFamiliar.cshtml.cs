using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarFamiliarModel : PageModel
   {
        private static IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Familiar familiar {get; set;}

        public ActionResult OnGet(int id)
        {
            this.familiar = _repositorioFamiliar.GetFamiliar(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                Familiar familiarActualizado = _repositorioFamiliar.UpdateFamiliar(familiar);
                return RedirectToPage("../Auxiliares/AdminAuxFmliar");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
