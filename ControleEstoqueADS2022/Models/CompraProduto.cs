using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueADS2022.Models
{
    [Table("Compra")]
    public class CompraProduto
    {
        [key]
        [Required(ErrorMessage = "ID é obrigatório")]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Cliente é obrigatório...")]
        [Display(Name = "Cliente: ")]
        public Cliente cliente { get; set; }

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

    }
}
