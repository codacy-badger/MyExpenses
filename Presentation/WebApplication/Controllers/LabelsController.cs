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

    using AutoMapper;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Domains;
    using MyExpenses.Infrastructure;

    using WebApplication.Models.Groups;
    using WebApplication.Models.Labels;

    [Authorize]
    public class LabelsController : Controller
    {
        private readonly ILabelAppService _appService;
        private readonly IGroupAppService _groupAppService;
        private readonly MyExpensesContext _context;
        private readonly UserManager<IdentityUser> _manager;

        public LabelsController(ILabelAppService appService, IGroupAppService groupAppService, MyExpensesContext context, UserManager<IdentityUser> manager)
        {
            _appService = appService;
            _groupAppService = groupAppService;
            _context = context;
            _manager = manager;
        }

        // GET: Labels
        public async Task<IActionResult> Index()
        {
            var userId = await GetCurrentUserIdAsync();
            var objs = _appService.GetAllWithIncludes(userId).ToList();
            var viewModel = new LabelsViewModel { Labels = objs.Select(Mapper.Map<LabelDto, LabelViewModel>).ToList() };

            return View(viewModel);
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
        public async Task<IActionResult> Create(LabelViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var userId = await GetCurrentUserIdAsync();

                // TODO temporary
                var firstGroupDto = _groupAppService.GetAllWithIncludes(userId).First();
                var firstGroupViewModel = Mapper.Map<GroupDto, GroupViewModel>(firstGroupDto);

                obj.Group = firstGroupViewModel;

                var dto = Mapper.Map<LabelViewModel, LabelDto>(obj);
                await _appService.AddAsync(dto);

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
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
        public async Task<IActionResult> Edit(Guid id, LabelDomain labelDomain)
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

        private async Task<Guid> GetCurrentUserIdAsync()
        {
            var user = await _manager.FindByNameAsync(User.Identity.Name);
            return Guid.Parse(user.Id);
        }
    }
}
