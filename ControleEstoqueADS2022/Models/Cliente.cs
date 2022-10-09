using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueADS2022.Models
{
    public enum Estado { AC, AL, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO }

    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é Obrigatório")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Campo cidade é Obrigatório")]
        [Display(Name = "Cidade: ")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Campo estado é Obrigatório")]
        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }

        [Display(Name = "Idade: ")]
        [Range(18, 100, ErrorMessage = "Idade entre 18...100")]
        public int idade { get; set; }

        public ICollection<CompraProduto> Compras { get; set; }
    }
}
