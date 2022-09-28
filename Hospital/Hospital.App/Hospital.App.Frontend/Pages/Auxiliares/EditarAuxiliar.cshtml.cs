using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarAuxiliarModel : PageModel
   {
        private static IRepositorioAuxiliar _repositorioAuxiliar = new RepositorioAuxiliar( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Auxiliar auxiliar {get; set;}

        public ActionResult OnGet(int id)
        {
            this.auxiliar = _repositorioAuxiliar.GetAuxiliar(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                Auxiliar auxiliarActualizado = _repositorioAuxiliar.UpdateAuxiliar(auxiliar);
                return RedirectToPage("./AdminAuxiliar");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
