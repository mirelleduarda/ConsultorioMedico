using Microsoft.EntityFrameworkCore;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cid> Cids { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}