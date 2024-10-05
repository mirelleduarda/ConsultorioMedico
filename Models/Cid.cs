using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedico.Models
{
    [Table("Cids")]
    public class Cid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo descricao é obrigatório")]
        [StringLength(45)]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }
    }
}