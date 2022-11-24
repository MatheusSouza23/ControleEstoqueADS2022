using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEstoqueADS2022.Models;

namespace ControleEstoqueADS2022.Controllers
{
    public class ComprasProdutosController : Controller
    {
        private readonly Contexto _context;

        public ComprasProdutosController(Contexto context)
        {
            _context = context;
        }

        // GET: ComprasProdutos
        public async Task<IActionResult> Index()
        {
              return View(await _context.compras.ToListAsync());
        }

        // GET: ComprasProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.compras == null)
            {
                return NotFound();
            }

            var compraProduto = await _context.compras
                .FirstOrDefaultAsync(m => m.id == id);
            if (compraProduto == null)
            {
                return NotFound();
            }

            return View(compraProduto);
        }

        // GET: ComprasProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComprasProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,quantidade,valor")] CompraProduto compraProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraProduto);
        }

        // GET: ComprasProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.compras == null)
            {
                return NotFound();
            }

            var compraProduto = await _context.compras.FindAsync(id);
            if (compraProduto == null)
            {
                return NotFound();
            }
            return View(compraProduto);
        }

        // POST: ComprasProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,quantidade,valor")] CompraProduto compraProduto)
        {
            if (id != compraProduto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraProdutoExists(compraProduto.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(compraProduto);
        }

        // GET: ComprasProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.compras == null)
            {
                return NotFound();
            }

            var compraProduto = await _context.compras
                .FirstOrDefaultAsync(m => m.id == id);
            if (compraProduto == null)
            {
                return NotFound();
            }

            return View(compraProduto);
        }

        // POST: ComprasProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.compras == null)
            {
                return Problem("Entity set 'Contexto.compras'  is null.");
            }
            var compraProduto = await _context.compras.FindAsync(id);
            if (compraProduto != null)
            {
                _context.compras.Remove(compraProduto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraProdutoExists(int id)
        {
          return _context.compras.Any(e => e.id == id);
        }
    }
}
