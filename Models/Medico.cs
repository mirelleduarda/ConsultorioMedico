using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedico.Models
{
    [Table("Medicos")]
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(45)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Display(Name = "Especialidade: ")]
        public Especialidade especialidade { get; set; }

        [Display(Name = "Especialidade: ")]
        public int especialidadeID { get; set; }

        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [StringLength(45)]
        [Display(Name = "Endereço: ")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo telefone é obrigatório")]
        [StringLength(13)]
        [Display(Name = "Telefone: ")]
        public string telefone { get; set; }

        [Display(Name = "Cidade: ")]
        public Cidade cidade { get; set; }

        [Display(Name = "Cidade: ")]
        public int cidadeID { get; set; }

        [Display(Name = "UF: ")]
        public string UF { get; set; }
    }
}
