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
    public class FornecedorsController : Controller
    {
        private readonly Contexto _context;

        public FornecedorsController(Contexto context)
        {
            _context = context;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
              return View(await _context.fornecedores.ToListAsync());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.fornecedores
                .FirstOrDefaultAsync(m => m.id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            var estado = Enum.GetValues(typeof(Estado)).Cast<Estado>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                });
            ViewBag.estado = estado;
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,CNPJ,nome,cidade,estado")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,CNPJ,nome,cidade,estado")] Fornecedor fornecedor)
        {
            if (id != fornecedor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.id))
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
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.fornecedores
                .FirstOrDefaultAsync(m => m.id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.fornecedores == null)
            {
                return Problem("Entity set 'Contexto.fornecedores'  is null.");
            }
            var fornecedor = await _context.fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.fornecedores.Remove(fornecedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
          return _context.fornecedores.Any(e => e.id == id);
        }
    }
}
