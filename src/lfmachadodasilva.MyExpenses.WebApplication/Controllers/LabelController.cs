using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lfmachadodasilva.MyExpenses.WebApplication.Data;
using lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using lfmachadodasilva.MyExpenses.Core.Services;
using lfmachadodasilva.MyExpenses.WebApplication.Services;
using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.WebApplication.Controllers
{
    [Authorize]
    public class LabelController : Controller
    {
        private readonly ILabelService _labelService;
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        public LabelController(
            ILabelService labelService,
            IGroupService groupService,
            IUserService userService)
        {
            _labelService = labelService;
            _groupService = groupService;
            _userService = userService;
        }

        // GET: Label
        public async Task<IActionResult> Index()
        {
            var userId = await _userService.GetUserIdAsync(User.Identity.Name);
            var groups = _groupService.GetAll(userId);

            var labels = new List<LabelViewModel>();

            return View(labels);
        }

        //// GET: Label/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var labelViewModel = await _context.LabelViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (labelViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(labelViewModel);
        //}

        //// GET: Label/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Label/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] LabelViewModel labelViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        labelViewModel.Id = Guid.NewGuid();
        //        _context.Add(labelViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(labelViewModel);
        //}

        //// GET: Label/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var labelViewModel = await _context.LabelViewModel.FindAsync(id);
        //    if (labelViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(labelViewModel);
        //}

        //// POST: Label/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] LabelViewModel labelViewModel)
        //{
        //    if (id != labelViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(labelViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LabelViewModelExists(labelViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(labelViewModel);
        //}

        //// GET: Label/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var labelViewModel = await _context.LabelViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (labelViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(labelViewModel);
        //}

        //// POST: Label/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var labelViewModel = await _context.LabelViewModel.FindAsync(id);
        //    _context.LabelViewModel.Remove(labelViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LabelViewModelExists(Guid id)
        //{
        //    return _context.LabelViewModel.Any(e => e.Id == id);
        //}
    }
}
