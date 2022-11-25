using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueADS2022.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :
                                                   base(options)
        { }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<CompraProduto> compras { get; set; }
        public DbSet<Fornecedor> fornecedores { get; set; }
        public DbSet<Estoque> estoques { get; set; }
    }
}
