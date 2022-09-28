using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages.Auxiliares
{
    public class AdminAuxEnfermeraModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Enfermeras
        public IEnumerable<Enfermera> Enfermeras;

        //Constructor
        public AdminAuxEnfermeraModel()
        {}

        public void OnGet()
        {
            Enfermeras = _repositorioEnfermera.GetAllEnfermeras();
        }
    }
}
