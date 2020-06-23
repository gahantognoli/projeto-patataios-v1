using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RankingPatataios.Data;
using RankingPatataios.Models;

namespace RankingPatataios.Controllers
{
    public class RodadasController : Controller
    {
        private readonly Context _context;

        public RodadasController(Context context)
        {
            _context = context;
        }

        // GET: Rodadas
        public async Task<IActionResult> Index()
        {
            var context = _context.Rodadas.Include(r => r.Torneio);
            return View(await context.ToListAsync());
        }

        // GET: Rodadas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodada = await _context.Rodadas
                .Include(r => r.Torneio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rodada == null)
            {
                return NotFound();
            }

            return View(rodada);
        }

        // GET: Rodadas/Create
        public IActionResult Create()
        {
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Codigo");
            return View();
        }

        // POST: Rodadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descricao,DataInicio,DataFim,Status,TorneioId,Id")] Rodada rodada)
        {
            if (ModelState.IsValid)
            {
                rodada.Id = Guid.NewGuid();
                _context.Add(rodada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Codigo", rodada.TorneioId);
            return View(rodada);
        }

        // GET: Rodadas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodada = await _context.Rodadas.FindAsync(id);
            if (rodada == null)
            {
                return NotFound();
            }
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Codigo", rodada.TorneioId);
            return View(rodada);
        }

        // POST: Rodadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Codigo,Descricao,DataInicio,DataFim,Status,TorneioId,Id")] Rodada rodada)
        {
            if (id != rodada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodadaExists(rodada.Id))
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
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Codigo", rodada.TorneioId);
            return View(rodada);
        }

        // GET: Rodadas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodada = await _context.Rodadas
                .Include(r => r.Torneio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rodada == null)
            {
                return NotFound();
            }

            return View(rodada);
        }

        // POST: Rodadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var rodada = await _context.Rodadas.FindAsync(id);
            _context.Rodadas.Remove(rodada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodadaExists(Guid id)
        {
            return _context.Rodadas.Any(e => e.Id == id);
        }
    }
}
