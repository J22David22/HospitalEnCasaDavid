using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearPacienteModel : PageModel
    
    {
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());
        private IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());
        private IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());
        private IRepositorioHistoriaClinica _repositorioHistoriaClinica = new RepositorioHistoriaClinica( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Paciente paciente {get; set;}
        [BindProperty]
        public Medico medico {get; set;}
        public IEnumerable<Medico> medicos;
        [BindProperty]
        public Enfermera enfermera {get; set;}
        public IEnumerable<Enfermera> enfermeras;
        [BindProperty]
        public HistoriaClinica historiaClinica {get; set;}

        public CrearPacienteModel()
        {}

        public ActionResult OnGet()
        {
            medicos = _repositorioMedico.GetAllMedicos();
            enfermeras = _repositorioEnfermera.GetAllEnfermeras();
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                
                
                paciente.MedicoId = medico.Id;
                paciente.EnfermeraId = enfermera.Id;
                
                
                Console.WriteLine("Medico Id: " + paciente.MedicoId);
                Paciente pacienteAdicionado = _repositorioPaciente.AddPaciente(paciente);
                historiaClinica.PacienteId = pacienteAdicionado.Id;
                historiaClinica.MedicoId = pacienteAdicionado.MedicoId;
                HistoriaClinica historiaClinicaAdicionado = _repositorioHistoriaClinica.AddHistoriaClinica(historiaClinica);
                pacienteAdicionado.HistoriaClinicaId = historiaClinicaAdicionado.Id;
                Paciente pacienteActualizado = _repositorioPaciente.UpdatePaciente(pacienteAdicionado);

                return RedirectToPage("../Auxiliares/AdminAuxPaciente");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
