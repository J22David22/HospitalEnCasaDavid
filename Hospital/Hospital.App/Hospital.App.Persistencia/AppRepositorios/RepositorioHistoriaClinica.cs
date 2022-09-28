using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioHistoriaClinica : IRepositorioHistoriaClinica
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioHistoriaClinica()
        {

        }
        public RepositorioHistoriaClinica(AppContext appContext)
        {
            this._appContext = appContext;
        }
        public HistoriaClinica AddHistoriaClinica(HistoriaClinica historiaClinica)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var historiaClinicaAdicionado = _appContext.HistoriasClinicas.Add(historiaClinica);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return historiaClinicaAdicionado.Entity;
        }
        public void DeleteHistoriaClinica(int idHistoriaClinica)
        {
            var historiaClinicaAEliminar = _appContext.HistoriasClinicas.FirstOrDefault(s => s.Id == idHistoriaClinica);

            /* select*from signo where u.Id = idhistoria */

            if (historiaClinicaAEliminar != null)
            {
                _appContext.HistoriasClinicas.Remove(historiaClinicaAEliminar);
                _appContext.SaveChanges();
            }
        }
        public HistoriaClinica GetHistoriaClinica(int idHistoriaClinica)
        {
            return _appContext.HistoriasClinicas.FirstOrDefault(s => s.Id == idHistoriaClinica);
        }
        public IEnumerable<HistoriaClinica> GetAllHistoriasClinicas()
        {
            return _appContext.HistoriasClinicas;
        }
        public HistoriaClinica UpdateHistoriaClinica(HistoriaClinica historiaClinica)
        {
            // Buscar usuario a actualizar

            var historiaClinicaEncontrado = _appContext.HistoriasClinicas.FirstOrDefault(s => s.Id == historiaClinica.Id);
            if (historiaClinicaEncontrado != null)
            {
                historiaClinicaEncontrado.PacienteId = historiaClinica.PacienteId;
                historiaClinicaEncontrado.MedicoId = historiaClinica.MedicoId;

                _appContext.SaveChanges();
            }

            return historiaClinicaEncontrado;
        }
        public IEnumerable<HistoriaClinica> GetHistoriaXPaciente(int idPaciente)
        {
            return
                this._appContext.HistoriasClinicas.Where(r => r.PacienteId == idPaciente);
        }
    }
}