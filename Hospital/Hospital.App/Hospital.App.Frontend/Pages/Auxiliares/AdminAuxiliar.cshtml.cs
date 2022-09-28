using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class AdminAuxiliarModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioAuxiliar _repositorioAuxiliar = new RepositorioAuxiliar( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Auxiliares
        public IEnumerable<Auxiliar> Auxiliares;

        //Constructor
        public AdminAuxiliarModel()
        {}

        public void OnGet()
        {
            Auxiliares = _repositorioAuxiliar.GetAllAuxiliares();
        }
    }
}
