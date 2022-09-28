using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class ListadoHistoriasEModel : PageModel
    {
        private IRepositorioHistoriaClinica _repoHistoria = new RepositorioHistoriaClinica(new Hospital.App.Persistencia.AppContext());

        private IRepositorioPaciente _repoPaciente = new RepositorioPaciente (new Hospital.App.Persistencia.AppContext());
        private IRepositorioMedico _repoMedico = new RepositorioMedico (new Hospital.App.Persistencia.AppContext());

        private IRepositorioDiagnostico _repoDiagnostico = new RepositorioDiagnostico (new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Paciente paciente{get;set;}

        [BindProperty]
        public Medico medico {get;set;}
        

        public ListadoHistoriasEModel()
        {}

        [BindProperty]
        public IEnumerable<Diagnostico> diagnosticos {get;set;}
        [BindProperty]
        public Diagnostico diagnostico{get;set; }

        [BindProperty]
        public HistoriaClinica historiaClinica{get;set;}
        
        public void OnGet(int id)
        {
            if ( id != null )
            {
                Console.WriteLine("listHistGet: " + id);
                paciente= _repoPaciente.GetPaciente(id);
                medico= _repoMedico.GetMedico(paciente.MedicoId);
                diagnosticos = _repoDiagnostico.GetDiagnosticosXPaciente(paciente.Id);
                historiaClinica = _repoHistoria.GetHistoriaClinica(paciente.HistoriaClinicaId);
                Console.WriteLine("hdiadnid: " + historiaClinica.Id);
            }
        }

    }
}
