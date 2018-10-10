/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;

    public class LabelsController : Controller
    {
        private readonly ILabelAppService _appService;

        public LabelsController(ILabelAppService appService)
        {
            _appService = appService;
        }

        // GET: Labels
        public async Task<IActionResult> Index()
        {
            var objs = await _appService.GetAll().ToListAsync();
            return View(objs);
        }

        // GET: Labels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelDomain = await _appService.GetByIdAsync(id.Value);
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
        public async Task<IActionResult> Create(LabelDto labelDomain)
        {
            if (ModelState.IsValid)
            {
                labelDomain.Id = Guid.NewGuid();

                await _appService.AddAsync(labelDomain);
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

            var labelDomain = await _appService.GetByIdAsync(id.Value);
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
        public async Task<IActionResult> Edit(Guid id, LabelDto labelDomain)
        {
            if (id != labelDomain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _appService.UpdateAsync(labelDomain);
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

            var labelDomain = await _appService.GetByIdAsync(id.Value);
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
            await _appService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LabelDomainExists(Guid id)
        {
            return _appService.GetAll().Any(e => e.Id == id);
        }
    }
}
