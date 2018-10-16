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
        public async Task<IActionResult> Index(Guid groupId)
        {
            var userId = await ControlUtil.GetCurrentUserIdAsync(_manager, User.Identity.Name);

            // groups
            var availableGroupsDto = _groupAppService.GetAllWithIncludes(userId);
            var availableGroupsViewModel = availableGroupsDto.Select(Mapper.Map<GroupDto, GroupViewModel>).ToList();

            if (groupId == Guid.Empty || !availableGroupsViewModel.Any(x => x.Id == groupId))
            {
                groupId = availableGroupsViewModel.Select(x => x.Id).FirstOrDefault();
            }
            else if (availableGroupsViewModel.Any(x => x.Id == groupId))
            {
                groupId = availableGroupsViewModel.Select(x => x.Id).FirstOrDefault(x => x == groupId);
            }
            else
            {
                groupId = Guid.Empty;
            }

            var objs = _appService.GetAllWithIncludes(groupId).ToList();
            var viewModel = new LabelsViewModel { Labels = objs.Select(Mapper.Map<LabelDto, LabelViewModel>).ToList(), GroupId = groupId };

            viewModel.SetupAvailableGroups(availableGroupsViewModel);

            return View(viewModel);
        }

        // GET: Labels/Create
        public async Task<IActionResult> Create()
        { 
            var availableGroupsViewModel = await ControlUtil.GetAvailableGroups(_manager, User.Identity.Name, _groupAppService);

            if (!availableGroupsViewModel.Any())
            {
                return RedirectToAction("Index", "Labels");
            }

            var viewModel = new LabelCreateEditViewModel(availableGroupsViewModel);

            return View(viewModel);
        }

        // POST: Labels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabelCreateEditViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var selectedGroupDto = await _groupAppService.GetByIdAsync(obj.SelectedGroupId);
                var selectedGroupViewModel = Mapper.Map<GroupDto, GroupViewModel>(selectedGroupDto);

                obj.Group = selectedGroupViewModel;

                var dto = Mapper.Map<LabelCreateEditViewModel, LabelDto>(obj);
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

            var labelDto = await _appService.GetByIdWithIncludes(id.Value);
            if (labelDto == null)
            {
                return NotFound();
            }

            var availableGroupsViewModel = await ControlUtil.GetAvailableGroups(_manager, User.Identity.Name, _groupAppService);

            if (!availableGroupsViewModel.Any())
            {
                return RedirectToAction("Index", "Labels");
            }

            var viewModel = Mapper.Map<LabelDto, LabelCreateEditViewModel>(labelDto);
            viewModel.SetupGroups(availableGroupsViewModel);
            viewModel.SelectedGroupId = viewModel.Group.Id;

            return View(viewModel);
        }

        // POST: Labels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LabelCreateEditViewModel obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var selectedGroupDto = await _groupAppService.GetByIdAsync(obj.SelectedGroupId);
                    var selectedGroupViewModel = Mapper.Map<GroupDto, GroupViewModel>(selectedGroupDto);

                    obj.Group = selectedGroupViewModel;

                    var dto = Mapper.Map<LabelCreateEditViewModel, LabelDto>(obj);
                    await _appService.UpdateAsync(dto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelDomainExists(obj.Id))
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

        //private async Task<Guid> GetCurrentUserIdAsync()
        //{
        //    var user = await _manager.FindByNameAsync(User.Identity.Name);
        //    return Guid.Parse(user.Id);
        //}

        //private async Task<ICollection<GroupViewModel>> GetAvailableGroups()
        //{
        //    var userId = await GetCurrentUserIdAsync();
        //    var availableGroupsDto = _groupAppService.GetAllWithIncludes(userId).ToList();
        //    var availableGroupsViewModel = availableGroupsDto.Select(Mapper.Map<GroupDto, GroupViewModel>).ToList();

        //    return availableGroupsViewModel;
        //}
    }
}
