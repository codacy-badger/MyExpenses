/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyExpenses.Domain.Domains;
    using MyExpenses.Infrastructure;

    public class LabelsController : Controller
    {
        private readonly MyExpensesContext _context;

        public LabelsController(MyExpensesContext context)
        {
            _context = context;
        }

        // GET: Labels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labels.ToListAsync());
        }

        // GET: Labels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelDomain = await _context.Labels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelDomain == null)
            {
                return NotFound();
            }

            return View(labelDomain);
        }

        // GET: Labels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,LastUpdate")] LabelDomain labelDomain)
        {
            if (ModelState.IsValid)
            {
                labelDomain.Id = Guid.NewGuid();
                _context.Add(labelDomain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labelDomain);
        }

        // GET: Labels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelDomain = await _context.Labels.FindAsync(id);
            if (labelDomain == null)
            {
                return NotFound();
            }
            return View(labelDomain);
        }

        // POST: Labels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,LastUpdate")] LabelDomain labelDomain)
        {
            if (id != labelDomain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labelDomain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelDomainExists(labelDomain.Id))
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
            return View(labelDomain);
        }

        // GET: Labels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelDomain = await _context.Labels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelDomain == null)
            {
                return NotFound();
            }

            return View(labelDomain);
        }

        // POST: Labels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var labelDomain = await _context.Labels.FindAsync(id);
            _context.Labels.Remove(labelDomain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelDomainExists(Guid id)
        {
            return _context.Labels.Any(e => e.Id == id);
        }
    }
}
