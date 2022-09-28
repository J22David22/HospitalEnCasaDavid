using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioSugerenciasCuidado : IRepositorioSugerenciasCuidado
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioSugerenciasCuidado()
        {

        }
        public RepositorioSugerenciasCuidado(AppContext appContext)
        {
            this._appContext = appContext;
        }
        public SugerenciasCuidado AddSugerenciasCuidado(SugerenciasCuidado sugerenciasCuidado)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var sugerenciaCuidadoAdicionado = _appContext.SugerenciasCuidados.Add(sugerenciasCuidado);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return sugerenciaCuidadoAdicionado.Entity;
        }
        public void DeleteSugerenciasCuidado(int idSugerenciasCuidado)
        {
            var sugerenciasCuidadoAEliminar = _appContext.SugerenciasCuidados.FirstOrDefault(s => s.Id == idSugerenciasCuidado);

            /* select*from signo where u.Id = idhistoria */

            if (sugerenciasCuidadoAEliminar != null)
            {
                _appContext.SugerenciasCuidados.Remove(sugerenciasCuidadoAEliminar);
                _appContext.SaveChanges();
            }
        }
        public SugerenciasCuidado GetSugerenciasCuidado(int idSugerenciasCuidado)
        {
            return _appContext.SugerenciasCuidados.FirstOrDefault(s => s.Id == idSugerenciasCuidado);
        }
        public IEnumerable<SugerenciasCuidado> GetAllSugerenciasCuidados()
        {
            return _appContext.SugerenciasCuidados;
        }
        public IEnumerable<SugerenciasCuidado> GetSugerenciaXDiagnostico(int idDiagnostico)
        {
            return _appContext.SugerenciasCuidados.Where(r => r.DiagnosticoId == idDiagnostico);
        }
        public SugerenciasCuidado UpdateSugerenciasCuidado(SugerenciasCuidado sugerenciasCuidado)
        {
            // Buscar usuario a actualizar

            var sugerenciasCuidadoEncontrado = _appContext.SugerenciasCuidados.FirstOrDefault(s => s.Id == sugerenciasCuidado.Id);
            if (sugerenciasCuidadoEncontrado != null)
            {
                sugerenciasCuidadoEncontrado.FechaHora = sugerenciasCuidado.FechaHora;
                sugerenciasCuidadoEncontrado.Descripcion = sugerenciasCuidado.Descripcion;
                //sugerenciasCuidadoEncontrado.HistoriaClinicaId = sugerenciasCuidado.HistoriaClinicaId;
                
                _appContext.SaveChanges();
            }

            return sugerenciasCuidadoEncontrado;
        }
        // public IEnumerable<SugerenciasCuidado> GetSugerenciasXPaciente(int idPaciente)
       // {
         //   return
           //     this._appContext.SugerenciasCuidados.Where(r => r.PacienteId == idPaciente);
        //}
    }
}