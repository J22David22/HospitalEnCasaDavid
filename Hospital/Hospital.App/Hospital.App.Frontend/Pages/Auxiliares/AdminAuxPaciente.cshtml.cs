using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages.Auxiliares
{
    public class AdminAuxPacienteModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Pacientes
        public IEnumerable<Paciente> Pacientes;

        //Constructor
        public AdminAuxPacienteModel()
        {}

        public void OnGet()
        {
            Pacientes = _repositorioPaciente.GetAllPacientes();
        }
    }
}
