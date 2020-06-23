using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RankingPatataios.Data;
using RankingPatataios.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RankingPatataios.Controllers
{
    public class JogoJogadoresController : Controller
    {
        private readonly Context _context;

        public JogoJogadoresController(Context context)
        {
            _context = context;
        }

        // GET: JogoJogadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.JogosJogadores.Include(c => c.Jogador).Include(c => c.Jogo).ToListAsync());
        }

        // GET: JogoJogadors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoJogador = await _context.JogosJogadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoJogador == null)
            {
                return NotFound();
            }

            return View(jogoJogador);
        }

        // GET: JogoJogadors/Create
        public IActionResult Create()
        {
            ViewData["JogoId"] = new SelectList(_context.Jogos, "Id", "Codigo");
            ViewData["JogadorId"] = new SelectList(_context.Jogadores, "Id", "Codigo");
            return View();
        }

        // POST: JogoJogadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JogoJogador jogoJogador)
        {

            jogoJogador.Id = Guid.NewGuid();
            _context.Add(jogoJogador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: JogoJogadors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoJogador = await _context.JogosJogadores.FindAsync(id);
            if (jogoJogador == null)
            {
                return NotFound();
            }

            ViewData["JogoId"] = new SelectList(_context.Jogos, "Id", "Codigo");
            ViewData["JogadorId"] = new SelectList(_context.Jogadores, "Id", "Codigo");
            return View(jogoJogador);
        }

        // POST: JogoJogadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, JogoJogador jogoJogador)
        {
            if (id != jogoJogador.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(jogoJogador);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogoJogadorExists(jogoJogador.Id))
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

        // GET: JogoJogadors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoJogador = await _context.JogosJogadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoJogador == null)
            {
                return NotFound();
            }

            return View(jogoJogador);
        }

        // POST: JogoJogadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jogoJogador = await _context.JogosJogadores.FindAsync(id);
            _context.JogosJogadores.Remove(jogoJogador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoJogadorExists(Guid id)
        {
            return _context.JogosJogadores.Any(e => e.Id == id);
        }
    }
}
