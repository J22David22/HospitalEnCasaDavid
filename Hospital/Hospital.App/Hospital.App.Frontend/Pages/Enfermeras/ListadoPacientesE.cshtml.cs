using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoPacientesEModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());
        private  IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());
        // Declaro una variable para la lista de PacientesM
        public IEnumerable<Paciente> PacientesE;
        public Enfermera enfermera{ get; set; }
        

        //Constructor
        public ListadoPacientesEModel()
        {}

        public void OnGet(int id)
        {
            PacientesE = _repositorioPaciente.GetAllPacientes();
            enfermera = _repositorioEnfermera.GetEnfermera(id);
            PacientesE = PacientesE.Where(p => p.EnfermeraId == id);
        }
    }
}

