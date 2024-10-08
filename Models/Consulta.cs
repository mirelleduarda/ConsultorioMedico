using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedico.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int ID { get; set; }


        [Display(Name = "Paciente: ")]
        public Paciente paciente { get; set; }

        [Display(Name = "Paciente: ")]
        public int pacienteID { get; set; }

        [Display(Name = "Cidade: ")]
        public Cidade cidade { get; set; }

        [Display(Name = "Cidade: ")]
        public string pacienteCidadeID { get; set; }

        [Display(Name = "UF: ")]
        public string pacienteUFID { get; set; }



        [Display(Name = "Médico: ")]
        public Medico medico { get; set; }

        [Display(Name = "Médico: ")]
        public int medicoID { get; set; }

        [Display(Name = "Especialidade: ")]
        public Especialidade especialidade { get; set; }

        [Display(Name = "Especialidade: ")]
        public string medicoEspecialidadeID { get; set; }



        [Display(Name = "CID: ")]
        public Cid cid { get; set; }

        [Display(Name = "CID: ")]
        public int cidID { get; set; }



        [Display(Name = "Medicamento: ")]
        public Medicamento medicamento { get; set; }

        [Display(Name = "Medicamento: ")]
        public int medicamentoID { get; set; }


        [Range(0, 1, ErrorMessage = "A quantidade de medicamentos deve ser entre 0 e 1.")]
        [Display(Name = "Quantidade: ")]
        public int qtdeMedicamento { get; set; }


        [Display(Name = "Valor: ")]
        public decimal? valorConsulta { get; set; }
    }
}
