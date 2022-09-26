using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoSignosVitalesModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioSignoVital _repositorioSignoVital = new RepositorioSignoVital( new Hospital.App.Persistencia.AppContext());
        private  IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());
         private IRepositorioPersona _repoPersona = new RepositorioPersona (new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de SignoVitals
        public IEnumerable<SignoVital> SignosVitales;
        [BindProperty]
        public SignoVital signoVital {get;set;}
        [BindProperty]
        public Paciente paciente {get; set;}

        public DateTime fechaInf{ get; set; }
        public DateTime fechaSup{ get; set; }
        [BindProperty]
        public Persona Persona {get;set;}

        //Constructor
        public ListadoSignosVitalesModel()
        {}

        public void OnGet( int id)
        {
            fechaInf=new DateTime(0022, 01, 01);
            fechaSup = DateTime.Now;
            paciente=_repositorioPaciente.GetPaciente(id);
            Persona= _repoPersona.GetPersona(id);
            Console.WriteLine("idlistado:"+paciente.Id);
            fechaInf=Convert.ToDateTime(TempData["fechaInf"]);
            fechaSup=Convert.ToDateTime(TempData["fechaSup"]);
            if (fechaInf == new DateTime(0001, 01, 01))
            {
                fechaInf = new DateTime(0001, 01, 01);
            }
            if (fechaSup == new DateTime(0001, 01, 01))
            {
                fechaSup = DateTime.Now;
            }
            SignosVitales = _repositorioSignoVital.GetSignosVitalesXFecha(fechaInf, fechaSup, paciente.Id);
            Console.WriteLine("fechainf: "+TempData["fechaInf"]);
            Console.WriteLine("fechasup: "+TempData["fechaSup"]);

        }
        public ActionResult OnPost(DateTime fechaInf, DateTime fechaSup, int id)
        {
            TempData["idpaciente"]=paciente.Id;
            TempData["fechaInf"]=fechaInf;
            TempData["fechaSup"]=fechaSup;
            Console.WriteLine("tempeditar:"+TempData["idpaciente"]);
            Console.WriteLine("fechainf: "+fechaInf);
            Console.WriteLine("fechasup: "+fechaSup);
            Console.WriteLine("idpost: "+id);
            string str=TempData["idpaciente"].ToString();
            return Redirect("/Pacientes/SignosVitales/ListadoSignosVitales?id="+str);
        }
        
    }
}

