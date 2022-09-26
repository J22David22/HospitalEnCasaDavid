using System;

namespace Hospital.App.Dominio

{
    public class SugerenciasCuidado
    {
        public int Id {get;set;}
        public DateTime FechaHora{get;set;}
        public string Descripcion {get;set;}
        public int? HistoriaClinicaId {get;set;}
        
    }


}