using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class ListaSugerenciasCuidadoEModel : PageModel
    {
        public ListaSugerenciasCuidadoEModel()
        {
        }
        private IRepositorioPaciente _repoPaciente = new RepositorioPaciente (new Hospital.App.Persistencia.AppContext());
        private IRepositorioDiagnostico _repoDiagnostico = new RepositorioDiagnostico (new Hospital.App.Persistencia.AppContext());
        private IRepositorioPersona _repoPersona = new RepositorioPersona (new Hospital.App.Persistencia.AppContext());
        private IRepositorioSugerenciasCuidado _repoSugerencias = new RepositorioSugerenciasCuidado(new Hospital.App.Persistencia.AppContext());
        private IRepositorioHistoriaClinica _repoHistoria = new RepositorioHistoriaClinica(new Hospital.App.Persistencia.AppContext());
        [BindProperty]
        public Paciente paciente{get;set;}
        [BindProperty]
        public Diagnostico diagnostico{get;set;}
        
        [BindProperty]
        public HistoriaClinica historiaClinica{get;set;}
        
        [BindProperty]
        public IEnumerable<SugerenciasCuidado> sugerenciasCuidados {get;set;}
        public void OnGet(int Id)
        {
            diagnostico = _repoDiagnostico.GetDiagnostico(Id);
            Console.WriteLine("diagno: " + diagnostico.DiagnosticoMedico);
            sugerenciasCuidados= _repoSugerencias.GetSugerenciaXDiagnostico(diagnostico.Id);
            Console.WriteLine("idhc: " + Id);
            
            historiaClinica = _repoHistoria.GetHistoriaClinica(Id);
        }
    }
}
