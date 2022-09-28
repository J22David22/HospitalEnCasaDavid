using System;

namespace Hospital.App.Dominio
{



public class HistoriaClinica
{
    public int Id {get;set;}
    public List<Diagnostico>? Diagnosticos {get;set;}

    public List<SugerenciasCuidado>? SugerenciasCuidado {get;set;}

    public int PacienteId {get; set;}
    public int MedicoId {get; set;}
  
    

}

}