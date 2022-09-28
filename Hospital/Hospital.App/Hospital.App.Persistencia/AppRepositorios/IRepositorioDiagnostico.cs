using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioDiagnostico
    {
        IEnumerable <Diagnostico> GetAllDiagnosticos();
        IEnumerable <Diagnostico> GetDiagnosticosXFecha(DateTime fechaInf, DateTime fechaSup, int idp);
        IEnumerable<Diagnostico> GetDiagnosticosXPaciente(int idp);

        Diagnostico AddDiagnostico (Diagnostico diagnostico);

        Diagnostico UpdateDiagnostico (Diagnostico diagnostico);

        public void DeleteDiagnostico (int idDiagnostico);

        public Diagnostico GetDiagnostico (int idDiagnostico);
    }
}