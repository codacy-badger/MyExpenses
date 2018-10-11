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

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Domain.Domains;
    using MyExpenses.Infrastructure;

    [Authorize]
    public class LabelsController : Controller
    {
        private readonly ILabelAppService _appService;
        private readonly MyExpensesContext _context;
        private readonly UserManager<IdentityUser> _manager;

        public LabelsController(ILabelAppService appService, MyExpensesContext context, UserManager<IdentityUser> manager)
        {
            _appService = appService;
            _context = context;
            _manager = manager;
        }

        // GET: Labels
        public async Task<IActionResult> Index()
        {
            var currentUser = await _manager.FindByNameAsync(User.Identity.Name);
            var userId = Guid.Parse(currentUser.Id);

            var objs = _context.Labels
                           .Include(l => l.Group)
                           .Include(l => l.Group.Users)
                           .Where(l => l.Group.Users.Any(u => u.UserId == userId));

            return View(await objs.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Name,Id")] LabelDomain labelDomain)
        {
            if (ModelState.IsValid)
            {
                labelDomain.Id = Guid.NewGuid();

                var currentUser = await _manager.FindByNameAsync(User.Identity.Name);
                var userId = Guid.Parse(currentUser.Id);

                var newGroup = new GroupDomain();

                if(!_context.Groups.Any(x => x.Users.Any(y => y.Id == userId)))
                {
                    var group = new GroupDomain { Id = Guid.NewGuid(), Name = "josaeluizfelipeporae" };
                    var groupUser = new GroupUserDomain { Id = Guid.NewGuid(), UserId = userId, Group = group };
                    group.Users = new List<GroupUserDomain> { groupUser };

                    newGroup = _context.Groups.Add(group).Entity;
                    _context.SaveChanges();
                }

                labelDomain.Group = newGroup;

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
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] LabelDomain labelDomain)
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
