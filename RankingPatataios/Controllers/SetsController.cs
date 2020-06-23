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
    public class SetsController : Controller
    {
        private readonly Context _context;

        public SetsController(Context context)
        {
            _context = context;
        }

        // GET: Sets
        public async Task<IActionResult> Index()
        {
            var context = _context.Sets.Include(e => e.Jogo);
            return View(await context.ToListAsync());
        }

        // GET: Sets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Sets
                .Include(e => e.Jogo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@set == null)
            {
                return NotFound();
            }

            return View(@set);
        }

        // GET: Sets/Create
        public IActionResult Create()
        {
            ViewData["JogoId"] = new SelectList(_context.Jogos, "Id", "Codigo");
            return View();
        }

        // POST: Sets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,GamesGanhosJogador1,GamesGanhosJogador2,TieBreakJogador1,TieBreakJogador2,JogoId,Id")] Set @set)
        {
            if (ModelState.IsValid)
            {
                @set.Id = Guid.NewGuid();
                _context.Add(@set);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogoId"] = new SelectList(_context.Jogos, "Id", "Id", @set.JogoId);
            return View(@set);
        }

        // GET: Sets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Sets.FindAsync(id);
            if (@set == null)
            {
                return NotFound();
            }
            ViewData["JogoId"] = new SelectList(_context.Jogos, "Id", "Id", @set.JogoId);
            return View(@set);
        }

        // POST: Sets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Numero,GamesGanhosJogador1,GamesGanhosJogador2,TieBreakJogador1,TieBreakJogador2,JogoId,Id")] Set @set)
        {
            if (id != @set.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@set);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetExists(@set.Id))
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
            ViewData["JogoId"] = new SelectList(_context.Jogos, "Id", "Id", @set.JogoId);
            return View(@set);
        }

        // GET: Sets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Sets
                .Include(e => e.Jogo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@set == null)
            {
                return NotFound();
            }

            return View(@set);
        }

        // POST: Sets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @set = await _context.Sets.FindAsync(id);
            _context.Sets.Remove(@set);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetExists(Guid id)
        {
            return _context.Sets.Any(e => e.Id == id);
        }
    }
}
