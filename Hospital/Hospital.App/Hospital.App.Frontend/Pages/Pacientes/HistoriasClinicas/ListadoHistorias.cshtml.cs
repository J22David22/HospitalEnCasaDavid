using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class ListadoHistoriasModel : PageModel
    {
        private IRepositorioHistoriaClinica _repoHistoria = new RepositorioHistoriaClinica(new Hospital.App.Persistencia.AppContext());

        private IRepositorioPaciente _repoPaciente = new RepositorioPaciente (new Hospital.App.Persistencia.AppContext());
        private IRepositorioPersona _repoPersona = new RepositorioPersona (new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Paciente Paciente{get;set;}
        [BindProperty]
        public Persona Persona {get;set;}

        public ListadoHistoriasModel()
        {}


        public IEnumerable<HistoriaClinica> HistoriasClinicas{get;set;}
        
        public void OnGet(int id)
        {
            if ( id != null )
            {
                
                Persona= this._repoPersona.GetPersona(id);
                Paciente= this._repoPaciente.GetPaciente(id);
                HistoriasClinicas = this._repoHistoria.GetHistoriaXPaciente(id);
            }
        }
    }
}
