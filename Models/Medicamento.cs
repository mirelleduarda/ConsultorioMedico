using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedico.Models
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo descricao obrigatório")]
        [StringLength(35)]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo qtdeEstoque obrigatório")]
        [Display(Name = "Quantidade em Estoque: ")]
        public int qtdeEstoque { get; set; }

        [Required(ErrorMessage = "Campo estoqueMin obrigatório")]
        [Display(Name = "Estoque Mínimo: ")]
        public int estoqueMin { get; set; }

        [Required(ErrorMessage = "Campo estoqueMax obrigatório")]
        [Display(Name = "Estoque Máximo: ")]
        public int estoqueMax { get; set; }

        [Required(ErrorMessage = "Campo precoUnitario obrigatório")]
        [Display(Name = "Preço Unitário: ")]
        public float precoUnitario { get; set; }
    }
}
