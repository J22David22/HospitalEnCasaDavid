using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class LoginAuxiliaresModel : PageModel
    {
        private static IRepositorioAuxiliar _repositorioAuxiliar = new RepositorioAuxiliar( new Hospital.App.Persistencia.AppContext());

        public LoginAuxiliaresModel()
        {

        }
        public Auxiliar auxiliar { get; set; }
        public IEnumerable<Auxiliar> auxiliares;
        public string telefono {get;set;}
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(string telefono)
        {
            try{
                // Guardamos la lista de todos los auxiliares
                auxiliares=_repositorioAuxiliar.GetAllAuxiliares();
                Console.WriteLine("tel: "+ telefono);
                
                if (auxiliares != null)  
                {
                        
                        auxiliar = auxiliares.SingleOrDefault(s => s.NumeroTelefono.Contains(telefono)); 

                        if (auxiliar.NumeroTelefono==telefono )
                        {
                            var idAuxiliarEncontrado = auxiliar.Id;
                            string str=idAuxiliarEncontrado.ToString();
                            Console.WriteLine("Encontrado: " + auxiliar.Nombre);
                            return Redirect("./VerAuxiliar?id="+str);
                        }
                        else{
                            return Page();
                        }
                
                }
                //paciente = _repositorioPaciente.GetPaciente(id);
                /*if(paciente.NumeroTelefono==telefono)
                {
                    return RedirectToPage("/Pacientes/ListadoPacientes");
                }
                else
                {
                    return RedirectToPage("/Index");
                }

                */
                return Page();
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
