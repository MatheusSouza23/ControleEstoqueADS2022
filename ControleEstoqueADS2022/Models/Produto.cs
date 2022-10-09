using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueADS2022.Models
{
    public enum Tipo {Doces, Salgados, Fardarias, Limpeza, Perfumaria, FLV, Padaria, Açougue, Frios, Bebidas, FrenteLoja, UsoLoja}
    [Table("Produto")]
    public class Produto
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }

        [Display(Name = "Data: ")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime dataEntrega { get; set; }

        [Display(Name = "Data: ")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime dataValidade { get; set; }

        [Required(ErrorMessage ="O campo Tipo é obrigatório")]
        [Display(Name = "Tipo: ")]
        public Tipo tipo { get; set; }

        [Display(Name = "Venda: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float preço { get; set; }

        public ICollection<CompraProduto> Compras { get; set; }
    }
}
