using System;

namespace Hospital.App.Dominio
{
public class Familiar: Persona
{
    public string DireccionFamiliar {get;set;}
    public string Parentesco {get;set;}
    public string Correo {get; set;}
    public int FamiliarPacienteId {get;set;}
    
}

}