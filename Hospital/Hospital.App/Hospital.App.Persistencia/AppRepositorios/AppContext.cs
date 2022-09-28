using Microsoft.EntityFrameworkCore;
using Hospital.App.Dominio;


namespace Hospital.App.Persistencia
{
    public class AppContext: DbContext
    {
        // La Entidad usuario

        public DbSet<Persona> Personas {get; set;}
        public DbSet<Enfermera> Enfermeras {get; set;}
        public DbSet<Auxiliar> Auxiliares {get;set;}
        public DbSet<Medico> Medicos {get;set;}
        public DbSet<Paciente> Pacientes {get;set;}
        public DbSet<Familiar> Familiares {get;set;}
        public DbSet<SugerenciasCuidado> SugerenciasCuidados {get;set;}
        public DbSet<HistoriaClinica> HistoriasClinicas {get;set;}
        public DbSet<SignoVital> SignosVitales {get;set;}
        public DbSet<Diagnostico> Diagnosticos {get;set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog= Hospital");
            }
        }
    }
}