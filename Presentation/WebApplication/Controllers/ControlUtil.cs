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

    using Microsoft.AspNetCore.Identity;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;

    using WebApplication.Models.Groups;

    public static class ControlUtil
    {
        public static async Task<Guid> GetCurrentUserIdAsync(UserManager<IdentityUser> manager, string userName)
        {
            var user = await manager.FindByNameAsync(userName);
            return Guid.Parse(user.Id);
        }

        public static async Task<ICollection<GroupViewModel>> GetAvailableGroups(
            UserManager<IdentityUser> manager,
            string userName,
            IGroupAppService groupAppService)
        {
            var userId = await GetCurrentUserIdAsync(manager, userName);
            var availableGroupsDto = groupAppService.GetAllWithIncludes(userId).ToList();
            var availableGroupsViewModel = availableGroupsDto.Select(Mapper.Map<GroupDto, GroupViewModel>).ToList();

            return availableGroupsViewModel;
        }
    }
}
