using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueADS2022.Models
{   
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo CNPJ é Obrigaório")]
        [Display(Name = "CNPJ: ")]
        public int CNPJ { get; set; }     

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é Obrigatório")]
        [Display(Name = "Nome da Empresa: ")]
        public string nome { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Campo cidade é Obrigatório")]
        [Display(Name = "Cidade: ")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Campo estado é Obrigatório")]
        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }

        public ICollection<Estoque> Estoques { get; set; }
    }
}
