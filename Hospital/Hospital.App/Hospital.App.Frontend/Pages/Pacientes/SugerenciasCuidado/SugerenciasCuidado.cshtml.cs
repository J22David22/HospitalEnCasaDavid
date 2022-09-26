using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class SugerenciasCuidadoModel : PageModel
    {
        private IRepositorioPaciente _repoPaciente = new RepositorioPaciente (new Hospital.App.Persistencia.AppContext());
        private IRepositorioPersona _repoPersona = new RepositorioPersona (new Hospital.App.Persistencia.AppContext());
        private IRepositorioSugerenciasCuidados _repoSugerencias = new RepositorioSugerenciasCuidado(new Hospital.App.Persistencia.AppContext());
        private IRepositorioHistoriaClinica _repoHistoria = new RepositorioHistoriaClinica(new Hospital.App.Persistencia.AppContext());
        [BindProperty]
        public Paciente Paciente{get;set;}
        [BindProperty]
        public Persona Persona {get;set;}

        [BindProperty]
        public HistoriaClinica HistoriaClinica{get;set;}
        public SugerenciasCuidadoModel()
        {

        }

        public IEnumerable<SugerenciasCuidado> SugerenciasCuidados {get;set;}
        public void OnGet()
        {
            SugerenciasCuidados= _repoSugerencias.GetAllSugerenciasCuidados();
        }
    }
}
