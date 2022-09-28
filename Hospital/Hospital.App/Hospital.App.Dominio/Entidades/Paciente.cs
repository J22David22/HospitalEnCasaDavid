using System;

namespace Hospital.App.Dominio
{
    public class Paciente: Persona
    {
       
       public string Direccion {get;set;}
       public double Latitud {get; set;}
       public double Longitud {get;set;}
       public string Ciudad {get; set;}
       public DateTime FechaNacimiento {get;set;}

       public int MedicoId {get; set;}
       public int EnfermeraId {get;set;}
       public List<SignoVital> SignosVitales {get;set;}
       public List<Diagnostico> Diagnosticos {get;set;}
       public int HistoriaClinicaId {get;set;}
       //public HistoriaClinica HistoriaClinica {get;set;}
       
       
       //
       public int FamiliarDesignadoId {get;set;}
       //public Medico Medico {get;set;}
       //public Enfermera Enfermera {get;set;}
       //public FamiliarDesignado FamiliarDesignado {get; set;}


    }
}