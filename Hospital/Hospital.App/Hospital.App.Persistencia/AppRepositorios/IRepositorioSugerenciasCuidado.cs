using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioSugerenciasCuidado
    {
        IEnumerable <SugerenciasCuidado> GetAllSugerenciasCuidados();
        
        SugerenciasCuidado AddSugerenciasCuidado (SugerenciasCuidado sugerenciasCuidado);

        SugerenciasCuidado UpdateSugerenciasCuidado (SugerenciasCuidado sugerenciasCuidado);

        public void DeleteSugerenciasCuidado (int idSugerenciasCuidado);

        public SugerenciasCuidado GetSugerenciasCuidado (int idSugerenciasCuidado);

        public IEnumerable<SugerenciasCuidado> GetSugerenciaXDiagnostico(int idDiagnostico);
        //public IEnumerable<SugerenciasCuidado> GetSugerenciasXPaciente(int idPaciente);
    }
}