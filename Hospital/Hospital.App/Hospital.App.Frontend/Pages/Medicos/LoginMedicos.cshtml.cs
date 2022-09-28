using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class LoginMedicosModel : PageModel
    {
        private static IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());

        public LoginMedicosModel()
        {

        }
        public Medico medico { get; set; }
        public IEnumerable<Medico> medicos;
        public string telefono {get;set;}
        public string password {get;set;}
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(string telefono)
        {
            try{
                // Guardamos la lista de todos los medicos
                medicos=_repositorioMedico.GetAllMedicos();
                Console.WriteLine("tel: "+ telefono );
                
                if (medicos != null)  
                {
                  

                  
                        medico = medicos.SingleOrDefault(s => s.NumeroTelefono.Contains(telefono)); 

                        if (medico.NumeroTelefono==telefono )
                        {
                            var idMedicoEncontrado = medico.Id;
                            string str=idMedicoEncontrado.ToString();
                            Console.WriteLine("Encontrado: " + medico.Nombre);
                            return Redirect("./VerMedico?id="+str);
                        }
                        else{
                            return Page();
                        }
                
                
                }
                //medico = _repositorioMedico.GetMedico(id);
                /*if(medico.NumeroTelefono==telefono)
                {
                    return RedirectToPage("/Medicos/ListadoMedicos");
                }
                else
                {
                    return RedirectToPage("/Index");
                }

                */

                       
                
                
                //paciente = _repositorioPaciente.GetPaciente(id);
                
                return Page();
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
