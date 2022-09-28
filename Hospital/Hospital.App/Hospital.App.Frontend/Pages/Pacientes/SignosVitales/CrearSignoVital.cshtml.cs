using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearSignoVitalModel : PageModel
    
    {
        private IRepositorioSignoVital _repositorioSignoVital = new RepositorioSignoVital( new Hospital.App.Persistencia.AppContext());
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public SignoVital signoVital {get; set;}
        [BindProperty]
        public Paciente paciente {get;set;}

        public int idpaciente {get;set;}

        public CrearSignoVitalModel()
        {}

        public ActionResult OnGet(int id)
        {
            Console.WriteLine("id get:"+id);
            idpaciente=Convert.ToInt32(TempData["idpaciente"]);
            TempData["pacienteid"]=idpaciente;
            TempData.Keep("pacienteid");
            paciente=_repositorioPaciente.GetPaciente(idpaciente);
            return Page();
            
        }

        public ActionResult OnPost()
        {
            try{
                idpaciente=Convert.ToInt32(TempData["pacienteid"]);
                signoVital.PacienteId = idpaciente;
                Console.WriteLine("Fecha: "+signoVital.FechaHora+ "Signo: "+signoVital.Signo+"Valor: "+signoVital.Valor+" PaciID: "+signoVital.PacienteId);
                SignoVital signoVitalAdicionado = _repositorioSignoVital.AddSignoVital(signoVital);
                return Redirect("/Pacientes/SignosVitales/ListadoSignosVitales?id="+idpaciente);
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
