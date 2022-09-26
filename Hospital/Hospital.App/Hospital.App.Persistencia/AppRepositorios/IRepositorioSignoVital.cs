using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioSignoVital
    {
        IEnumerable <SignoVital> GetAllSignosVitales();
        IEnumerable <SignoVital> GetSignosVitalesXFecha(DateTime fechaInf, DateTime fechaSup, int idp);
        
        SignoVital AddSignoVital (SignoVital signoVital);

        SignoVital UpdateSignoVital (SignoVital signoVital);

        public void DeleteSignoVital (int idSignoVital);

        public SignoVital GetSignoVital (int idSignoVital);
    }
}