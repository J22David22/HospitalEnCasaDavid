using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class AdminAuxiliarModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Pacientes
        public IEnumerable<Paciente> Pacientes;

        //Constructor
        public AdminAuxiliarModel()
        {}

        public void OnGet()
        {
            Pacientes = _repositorioPaciente.GetAllPacientes();
        }
    }
}
