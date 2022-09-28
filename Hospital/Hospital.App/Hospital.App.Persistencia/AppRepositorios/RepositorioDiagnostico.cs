using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioDiagnostico : IRepositorioDiagnostico
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioDiagnostico()
        {
            
        }
        public RepositorioDiagnostico (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public Diagnostico AddDiagnostico(Diagnostico diagnostico)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var diagnosticoAdicionado = _appContext.Diagnosticos.Add(diagnostico);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return diagnosticoAdicionado.Entity;
        }
        public void DeleteDiagnostico(int idDiagnostico)
        {
            var diagnosticoAEliminar=_appContext.Diagnosticos.FirstOrDefault(s => s.Id == idDiagnostico);

            /* select*from signo where u.Id = idhistoria */

            if (diagnosticoAEliminar !=null)
            {
                _appContext.Diagnosticos.Remove(diagnosticoAEliminar);
                _appContext.SaveChanges();
            }
        }
        public Diagnostico GetDiagnostico (int idDiagnostico)
        {
           return _appContext.Diagnosticos.FirstOrDefault( s => s.Id == idDiagnostico);
        }
        public IEnumerable<Diagnostico> GetAllDiagnosticos()
        {
            return _appContext.Diagnosticos;
        }
        public IEnumerable<Diagnostico> GetDiagnosticosXFecha(DateTime fechaInf, DateTime fechaSup, int idp)
        {
            return _appContext.Diagnosticos.Where(s => s.FechaDiagnostico >= fechaInf & s.FechaDiagnostico <= fechaSup & s.PacienteId==idp);
        }
        public IEnumerable<Diagnostico> GetDiagnosticosXPaciente(int idp)
        {
            return _appContext.Diagnosticos.Where(s => s.PacienteId==idp);
        }
        public Diagnostico UpdateDiagnostico(Diagnostico diagnostico)
        {
            // Buscar usuario a actualizar

            var diagnosticoEncontrado = _appContext.Diagnosticos.FirstOrDefault(s => s.Id == diagnostico.Id);
            if (diagnosticoEncontrado != null)
            {
                diagnosticoEncontrado.FechaDiagnostico=diagnostico.FechaDiagnostico;
                diagnosticoEncontrado.DiagnosticoMedico=diagnostico.DiagnosticoMedico;
                               
                _appContext.SaveChanges();
            }

            return diagnosticoEncontrado;
        }
    }
}