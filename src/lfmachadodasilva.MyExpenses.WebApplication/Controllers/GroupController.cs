using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lfmachadodasilva.MyExpenses.WebApplication.Services;
using Microsoft.AspNetCore.Authorization;

namespace lfmachadodasilva.MyExpenses.WebApplication.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IGroupWebService _groupWebService;
        private readonly IUserService _userService;

        public GroupController(IGroupWebService groupWebService, IUserService userService)
        {
            _groupWebService = groupWebService;
            _userService = userService;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var userId = await _userService.GetUserIdAsync(User.Identity.Name);
            var groups = _groupWebService.GetAllByUserAsync(userId);

            return Ok(groups);
        }

        //// GET: Group/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var groupViewModel = await _context.GroupViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (groupViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(groupViewModel);
        //}

        //// GET: Group/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Group/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Id")] GroupViewModel groupViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        groupViewModel.Id = Guid.NewGuid();
        //        _context.Add(groupViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(groupViewModel);
        //}

        //// GET: Group/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var groupViewModel = await _context.GroupViewModel.FindAsync(id);
        //    if (groupViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(groupViewModel);
        //}

        //// POST: Group/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] GroupViewModel groupViewModel)
        //{
        //    if (id != groupViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(groupViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GroupViewModelExists(groupViewModel.Id))
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
        //    return View(groupViewModel);
        //}

        //// GET: Group/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var groupViewModel = await _context.GroupViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (groupViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(groupViewModel);
        //}

        //// POST: Group/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var groupViewModel = await _context.GroupViewModel.FindAsync(id);
        //    _context.GroupViewModel.Remove(groupViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GroupViewModelExists(Guid id)
        //{
        //    return _context.GroupViewModel.Any(e => e.Id == id);
        //}
    }
}
