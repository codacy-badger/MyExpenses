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

    using AutoMapper;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;

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
            var objs = _service.GetAllWithIncludes(userId).ToList();
            var viewModel = new GroupsViewModel { Groups = objs.Select(Mapper.Map<GroupDto, GroupViewModel>).ToList() };

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
            var viewModel = new GroupCreateEditViewModel(_manager.Users);

            return View(viewModel);
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupCreateEditViewModel obj)
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

            var obj = _service.GetByIdWithIncludeAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var viewModel = new GroupCreateEditViewModel(_manager.Users, obj.Users.Select(x => x.UserId).ToList())
            {
                Id = obj.Id,
                Name = obj.Name
            };

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
    }
}
