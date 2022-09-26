using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioSignoVital : IRepositorioSignoVital
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioSignoVital()
        {
            
        }
        public RepositorioSignoVital (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public SignoVital AddSignoVital(SignoVital signoVital)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var signoVitalAdicionado = _appContext.SignosVitales.Add(signoVital);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return signoVitalAdicionado.Entity;
        }
        public void DeleteSignoVital(int idSignoVital)
        {
            var signoVitalAEliminar=_appContext.SignosVitales.FirstOrDefault(s => s.Id == idSignoVital);

            /* select*from signo where u.Id = idhistoria */

            if (signoVitalAEliminar !=null)
            {
                _appContext.SignosVitales.Remove(signoVitalAEliminar);
                _appContext.SaveChanges();
            }
        }
        public SignoVital GetSignoVital (int idSignoVital)
        {
           return _appContext.SignosVitales.FirstOrDefault( s => s.Id == idSignoVital);
        }
        public IEnumerable<SignoVital> GetAllSignosVitales()
        {
            return _appContext.SignosVitales;
        }
        public IEnumerable<SignoVital> GetSignosVitalesXFecha(DateTime fechaInf, DateTime fechaSup, int idp)
        {
            return _appContext.SignosVitales.Where(s => s.FechaHora >= fechaInf & s.FechaHora <= fechaSup & s.PacienteId==idp);
        }
        public SignoVital UpdateSignoVital(SignoVital signoVital)
        {
            // Buscar usuario a actualizar

            var signoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(s => s.Id == signoVital.Id);
            if (signoVitalEncontrado != null)
            {
                signoVitalEncontrado.PacienteId=signoVital.PacienteId;
                signoVitalEncontrado.FechaHora=signoVital.FechaHora;
                signoVitalEncontrado.Signo=signoVital.Signo;
                signoVitalEncontrado.Valor=signoVital.Valor;
                               
                _appContext.SaveChanges();
            }

            return signoVitalEncontrado;
        }
    }
}