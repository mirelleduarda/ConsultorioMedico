using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedico.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [StringLength(45)]
        [Display(Name = "Endereço: ")]
        public string endereco { get; set; }

        [Display(Name = "Cidade: ")]
        public Cidade cidade { get; set; }

        [Display(Name = "Cidade: ")]
        public int cidadeID { get; set; }

        [Display(Name = "UF: ")]
        public string UFID { get; set; }
    }
}
