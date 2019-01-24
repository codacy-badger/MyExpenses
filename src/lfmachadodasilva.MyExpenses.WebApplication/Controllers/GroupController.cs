using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.WebApplication.Data;
using lfmachadodasilva.MyExpenses.WebApplication.Services;
using lfmachadodasilva.MyExpenses.WebApplication.Models;

namespace lfmachadodasilva.MyExpenses.WebApplication.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGroupAppService _groupAppService;

        public GroupController(ApplicationDbContext context, IGroupAppService groupAppService)
        {
            _context = context;
            _groupAppService = groupAppService;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var viewModels = await _groupAppService.GetAllAsync();
            return View(viewModels);
        }

        // GET: Group/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupDto = await _context.GroupDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupDto == null)
            {
                return NotFound();
            }

            return View(groupDto);
        }

        // GET: Group/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                //groupDto.Id = Guid.NewGuid();
                //_context.Add(groupDto);
                //await _context.SaveChangesAsync();
                await _groupAppService.AddAsync(groupViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(groupViewModel);
        }

        // GET: Group/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupDto = await _context.GroupDto.FindAsync(id);
            if (groupDto == null)
            {
                return NotFound();
            }
            return View(groupDto);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] GroupDto groupDto)
        {
            if (id != groupDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupDtoExists(groupDto.Id))
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
            return View(groupDto);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupDto = await _context.GroupDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupDto == null)
            {
                return NotFound();
            }

            return View(groupDto);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var groupDto = await _context.GroupDto.FindAsync(id);
            _context.GroupDto.Remove(groupDto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupDtoExists(Guid id)
        {
            return _context.GroupDto.Any(e => e.Id == id);
        }
    }
}
