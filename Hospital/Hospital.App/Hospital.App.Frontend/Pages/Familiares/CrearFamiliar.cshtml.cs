using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearFamiliarModel : PageModel
    
    {
        private IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar( new Hospital.App.Persistencia.AppContext());
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Familiar familiar {get; set;}
        [BindProperty]
        public IEnumerable <Paciente> pacientes{ get; set; }
        [BindProperty]
        public Paciente paciente{ get; set; }

        public CrearFamiliarModel()
        {}

        public ActionResult OnGet()
        {
            pacientes = _repositorioPaciente.GetAllPacientes();
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                Console.WriteLine("Fami Pac Id: " );
                familiar.FamiliarPacienteId = paciente.Id;
                paciente = _repositorioPaciente.GetPaciente(paciente.Id);
                Console.WriteLine("Fami Pac Id: " + familiar.FamiliarPacienteId);
                Console.WriteLine("Fami Pac Id: " + paciente.Direccion);
                Familiar familiarAdicionado = _repositorioFamiliar.AddFamiliar(familiar);
                Console.WriteLine("Fami Pac Nombre: " + familiarAdicionado.Nombre);
                Console.WriteLine("Fami Pac Id: " + familiarAdicionado.Id);
                Console.WriteLine("Fami Pac Id: " + familiarAdicionado.FamiliarPacienteId);
                paciente.FamiliarDesignadoId = familiarAdicionado.Id;
                Console.WriteLine("Fami Pac Id: " + paciente.FamiliarDesignadoId);
                Paciente pacienteAdicionado = _repositorioPaciente.UpdatePaciente(paciente);
                Console.WriteLine("Fami Pac Id: " + pacienteAdicionado.Nombre);
                familiarAdicionado.FamiliarPacienteId = pacienteAdicionado.Id;
                Familiar familiarActualizado = _repositorioFamiliar.UpdateFamiliar(familiarAdicionado);
                
                return RedirectToPage("../Auxiliares/AdminAuxFmliar");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
