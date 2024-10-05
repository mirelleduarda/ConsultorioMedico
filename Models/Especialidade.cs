using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedico.Models
{
    [Table("Especialidades")]
    public class Especialidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }
    }
}
