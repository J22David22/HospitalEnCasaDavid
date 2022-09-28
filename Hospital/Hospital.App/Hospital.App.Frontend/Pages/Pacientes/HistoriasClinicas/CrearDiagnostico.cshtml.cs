using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearDiagnosticoModel : PageModel
    
    {
        private IRepositorioHistoriaClinica _repositorioHistoriaClinica = new RepositorioHistoriaClinica( new Hospital.App.Persistencia.AppContext());
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());
        private IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());
        private IRepositorioDiagnostico _repositorioDiagnostico = new RepositorioDiagnostico( new Hospital.App.Persistencia.AppContext());


        [BindProperty]
        public HistoriaClinica historiaClinica {get; set;}
        [BindProperty]
        public Paciente paciente {get;set;}
        public IEnumerable <Diagnostico>diagnosticos{ get; set; }
        [BindProperty]
        public Diagnostico diagnostico{ get; set; }
        public Medico medico {get;set;}

        public int pacienteid {get;set;}
        public int historiaid {get;set;}

        public DateTime fecha{ get; set; }

        public CrearDiagnosticoModel()
        {}

        public ActionResult OnGet(int id)
        {
            paciente=_repositorioPaciente.GetPaciente(id);
            medico=_repositorioMedico.GetMedico(paciente.MedicoId);
            historiaClinica = _repositorioHistoriaClinica.GetHistoriaClinica(paciente.HistoriaClinicaId);
            Console.WriteLine("idpac:" + paciente.Id+"idhicli: "+historiaClinica.Id+"idmedi: "+medico.Id);
            Console.WriteLine("idpa:" + paciente.Id+"idhicli: "+paciente.HistoriaClinicaId);
            
            return Page();
            
        }

        public ActionResult OnPost()
        {
            try{
                Console.WriteLine("entra al post:");
                diagnostico.PacienteId = paciente.Id;
                paciente = _repositorioPaciente.GetPaciente(paciente.Id);
                fecha = DateTime.Now;
                diagnostico.FechaDiagnostico = fecha;
                Console.WriteLine("fecha:" + diagnostico.FechaDiagnostico);
                //diagnostico.HistClinId = historiaClinica.Id;
                diagnostico.HistClinId = historiaClinica.Id;
                Console.WriteLine("hisclin:" + diagnostico.HistClinId);
                // HistoriaClinica.PacienteId = paciente.Id;
                Console.WriteLine("fecha:" + diagnostico.FechaDiagnostico+"diagn:" + diagnostico.DiagnosticoMedico+"pacid:" + diagnostico.PacienteId+"histclinc:" + diagnostico.HistClinId);
                // Console.WriteLine("id: "+HistoriaClinica.Id+" HistoriaClinica: "+HistoriaClinica.HistoriaClinica+ "Entorno: "+HistoriaClinica.Entorno+"PaciID: "+HistoriaClinica.PacienteId+" MediID: "+HistoriaClinica.MedicoId);
                Diagnostico diagnosticoAdicionado=_repositorioDiagnostico.AddDiagnostico(diagnostico);
                // Console.WriteLine("idpapost:" + historiaClinicaAdicionado.Id);
                return Redirect("/Pacientes/HistoriasClinicas/ListadoHistorias?id="+paciente.Id);
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
