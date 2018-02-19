using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KanbanDesk.Models;

namespace KanbanDesk.Controllers
{
    public class GoalsController : Controller
    {
        private readonly KanbanDeskContext _context;

        public GoalsController(KanbanDeskContext context)
        {
            _context = context;
        }

        // GET: Goals
        public async Task<IActionResult> Index()
        {

           var goals1 = from g in _context.Goals
                        where g.State == 1
                        select g;

           var goals2 = from g in _context.Goals
                         where g.State == 2
                         select g;
           var goals3 = from g in _context.Goals
                         where g.State == 3
                         select g;
            List<Goals>[] goals = {await goals1.ToListAsync(), await goals2.ToListAsync(), await goals3.ToListAsync() };

            return View(new IEnumerable<KanbanDesk.Models.Goals>[] { await goals1.ToListAsync(), await goals2.ToListAsync(), await goals3.ToListAsync()} );
        }

        // GET: Goals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goals = await _context.Goals
                .SingleOrDefaultAsync(m => m.ID == id);
            if (goals == null)
            {
                return NotFound();
            }

            return View(goals);
        }

        // GET: Goals/Create
        public IActionResult Create(int? state)
        {
            ViewBag.stateNew = state;
            return View();
        }

        // POST: Goals/Create/1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int state, [Bind("ID,Title,Description,State")] Goals goals)
        {
          
            if (ModelState.IsValid)
            {
                _context.Add(goals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goals);
        }

        // GET: Goals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goals = await _context.Goals.SingleOrDefaultAsync(m => m.ID == id);
            if (goals == null)
            {
                return NotFound();
            }
            return View(goals);
        }

        // POST: Goals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,State")] Goals goals)
        {
            if (id != goals.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalsExists(goals.ID))
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
            return View(goals);
        }

        // GET: Goals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goals = await _context.Goals
                .SingleOrDefaultAsync(m => m.ID == id);
            if (goals == null)
            {
                return NotFound();
            }

            return View(goals);
        }

        // POST: Goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goals = await _context.Goals.SingleOrDefaultAsync(m => m.ID == id);
            _context.Goals.Remove(goals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalsExists(int id)
        {
            return _context.Goals.Any(e => e.ID == id);
        }
    }
}
