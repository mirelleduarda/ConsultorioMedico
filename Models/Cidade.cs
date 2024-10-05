using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedico.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo UF é obrigatório")]
        [StringLength(2)]
        [Display(Name = "UF: ")]
        public string UF { get; set; }
    }
}
