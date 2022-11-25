namespace ControleEstoqueADS2022.Models.Consulta
{
    public class estoqueQRY
    {
        public int id { get; set; }
        public string produto { get; set; }   
        public float quantidade { get; set; }
        public int fornecedor { get; set; }
        public int cnpj { get; set; }
        public Estado estado { get; set; }
        public float valor { get; set; }
    }
}
