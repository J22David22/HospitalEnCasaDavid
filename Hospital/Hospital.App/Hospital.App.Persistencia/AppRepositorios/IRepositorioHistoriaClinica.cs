using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioHistoriaClinica
    {
        IEnumerable <HistoriaClinica> GetAllHistoriasClinicas();
        
        HistoriaClinica AddHistoriaClinica (HistoriaClinica historiaClinica);

        HistoriaClinica UpdateHistoriaClinica (HistoriaClinica historiaClinica);

        public void DeleteHistoriaClinica (int idHistoriaClinica);

        public HistoriaClinica GetHistoriaClinica (int idHistoriaClinica);
        public IEnumerable<HistoriaClinica> GetHistoriaXPaciente(int idPaciente);
    }
}