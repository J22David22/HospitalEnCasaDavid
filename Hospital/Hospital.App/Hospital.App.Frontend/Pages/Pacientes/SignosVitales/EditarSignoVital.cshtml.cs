using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarSignoVitalModel : PageModel
   {
        private IRepositorioSignoVital _repositorioSignoVital = new RepositorioSignoVital( new Hospital.App.Persistencia.AppContext());
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public SignoVital signoVital {get; set;}
        [BindProperty]
        public Paciente paciente {get;set;}

        public EditarSignoVitalModel()
        {}

        public ActionResult OnGet(int id)
        {
            signoVital = _repositorioSignoVital.GetSignoVital(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                Console.WriteLine("sigId: "+signoVital.Id +"sigSig: "+signoVital.Signo +"sigFec: "+signoVital.FechaHora +"sigVa: "+signoVital.Valor );
                SignoVital signoVitalEncontrado = _repositorioSignoVital.UpdateSignoVital(signoVital);
                Console.WriteLine("signo actualizado:"+signoVitalEncontrado.Valor);
                paciente = _repositorioPaciente.GetPaciente(signoVitalEncontrado.PacienteId);
                Console.WriteLine("signo actualizado:"+paciente.Id); 
                return Redirect("./ListadoSignosVitales?id="+paciente.Id);
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
