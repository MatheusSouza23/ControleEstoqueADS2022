using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueADS2022.Models
{
    [Table("Estoques")]
    public class Estoque
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }
        
        [Required(ErrorMessage = "ID do fornecedor é obrigatório")]
        [Display(Name = "ID Fornecedor: ")]
        public int idfornecedor { get; set; }

        public ICollection<CompraProduto> Compras { get; set; }
    }
}
