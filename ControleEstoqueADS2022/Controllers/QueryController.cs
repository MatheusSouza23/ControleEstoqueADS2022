using ControleEstoqueADS2022.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoqueADS2022.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto contexto;

        public QueryController (Contexto context) 
        {
            contexto = context;
        }

        public IActionResult Fornecedor(string nome)
        {
            List<Fornecedor> lista = new List<Fornecedor>();
            if (nome == null)
            {
                lista = contexto.fornecedores.OrderBy(e => e.estado)
                    .ThenBy(nom => nom.nome).ToList();
            }
            else
            {  
                lista = contexto.fornecedores.Where(n => n.nome.Contains(nome))
                    .OrderBy(e => e.estado)
                    .ThenBy(nom => nom.nome)
                    .ToList();
            }
            return View(lista);
        }

        public IActionResult Pesquisa()
        {
            return View();
        }

    }
}
