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
    public class JogosController : Controller
    {
        private readonly Context _context;

        public JogosController(Context context)
        {
            _context = context;
        }

        // GET: Jogoes
        public async Task<IActionResult> Index()
        {
            var context = _context.Jogos.Include(j => j.Rodada);
            return View(await context.ToListAsync());
        }

        // GET: Jogoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .Include(j => j.Rodada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // GET: Jogoes/Create
        public IActionResult Create()
        {
            ViewData["RodadaId"] = new SelectList(_context.Rodadas, "Id", "Codigo");
            return View();
        }

        // POST: Jogoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                jogo.Id = Guid.NewGuid();
                _context.Add(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RodadaId"] = new SelectList(_context.Rodadas, "Id", "Codigo", jogo.RodadaId);
            return View(jogo);
        }

        // GET: Jogoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }
            ViewData["RodadaId"] = new SelectList(_context.Rodadas, "Id", "Codigo", jogo.RodadaId);
            return View(jogo);
        }

        // POST: Jogoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Jogo jogo)
        {
            if (id != jogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.Id))
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
            ViewData["RodadaId"] = new SelectList(_context.Rodadas, "Id", "Codigo", jogo.RodadaId);
            return View(jogo);
        }

        // GET: Jogoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .Include(j => j.Rodada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: Jogoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(Guid id)
        {
            return _context.Jogos.Any(e => e.Id == id);
        }
    }
}
