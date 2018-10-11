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
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Infrastructure;

    using WebApplication.Models.Groups;

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
            var userId = await GetCurrentUserIdAsync();
            var t = _service.GetAllWithIncludes().ToList();
            var objs = await _service.GetAllWithIncludes().Where(g => g.Users.Any(u => u.UserId == userId)).ToListAsync();

            var viewModel = new GroupsViewModel
            {
                Groups = objs.Select(x => new GroupViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return View(viewModel);
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
            var viewModel = new GroupViewModel();
            viewModel.SetupUsers(_manager.Users);

            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var dto = new GroupDto
                {
                    Name = obj.Name
                };
                dto.Users = obj.SelectedUsersId.Select(x => new GroupUserDto { Group = dto, Id = Guid.NewGuid(), UserId = x }).ToList();

                await _service.AddAsync(dto);
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

            var obj = await _service.GetByIdWithIncludeAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var viewModel = new GroupViewModel
            {
                Id = obj.Id,
                Name = obj.Name
            };
            viewModel.SetupUsers(_manager.Users, obj.Users.Select(x => x.UserId).ToList());

            CreateSelectLists();

            return View(viewModel);
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
            var user = await _manager.FindByNameAsync(User.Identity.Name);
            return Guid.Parse(user.Id);
        }

        private void CreateSelectLists()
        {
            IEnumerable<GroupUserDto> users = _manager.Users.Select(u => new GroupUserDto { UserId = Guid.Parse(u.Id), UserName = u.UserName });
            ViewData["AllUsers"] = new SelectList(users, "UserId", "UserName");
        }
    }
}
