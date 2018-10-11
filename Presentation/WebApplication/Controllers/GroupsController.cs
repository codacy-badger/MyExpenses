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
    using System.Reflection.Emit;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Infrastructure;
    using MyExpenses.Infrastructure.Properties;

    [Authorize]
    public class GroupsController : Controller
    {
        private readonly IGroupAppService _service;
        private readonly UserManager<IdentityUser> _manager;

        public GroupsController(IGroupAppService service, UserManager<IdentityUser> manager)
        {
            _service = service;
            _manager = manager;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            //var user = await _manager.FindByIdAsync(User.Identity.Name);
            //var userId = Guid.Parse(user.Id);

            var objs = await _service.GetAll().ToListAsync(); //.Where(g => g.Users.Any(u => u.Id == userId)).ToListAsync();
            return View(objs);
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupDomain = await _service.GetByIdAsync(id.Value);
            if (groupDomain == null)
            {
                return NotFound();
            }

            return View(groupDomain);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            CreateSelectLists();
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupDto obj)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _service.GetByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var users = CreateSelectLists();
            obj.AllUsers = new List<string>();
            obj.AllUsers.Add(users.ToList()[1].UserId.ToString());

            return View(obj);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GroupDto obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(obj);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await GroupDomainExists(obj.Id))
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
            return View(obj);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupDomain = await _service.GetByIdAsync(id.Value);
            if (groupDomain == null)
            {
                return NotFound();
            }

            return View(groupDomain);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _service.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> GroupDomainExists(Guid id)
        {
            return await _service.GetByIdAsync(id) != null;
        }

        private async Task<Guid> GetCurrentUserIdAsync()
        {
            var user = await _manager.FindByIdAsync(User.Identity.Name);
            return Guid.Parse(user.Id);
        }

        private IEnumerable<GroupUserDto> CreateSelectLists()
        {
            IEnumerable<GroupUserDto> users = _manager.Users.Select(u => new GroupUserDto { UserId = Guid.Parse(u.Id), UserName = u.UserName });
            
            //IEnumerable<Payment> payments = _paymentService.Get();

            //Label[] l = { new Label { Id = -1, Name = string.Empty } };
            //lables = lables.Concat(l).OrderBy(x => x.Id);

            //Payment[] p = { new Payment { Id = -1, Name = string.Empty } };
            //payments = payments.Concat(p).OrderBy(x => x.Id);

            ViewData["Users"] = new SelectList(users, "UserId", "UserName");
            //ViewData[Resource.PaymentsViewData] = new SelectList(payments, "Id", "Name", paymentId);

            return users;
        }
    }
}
