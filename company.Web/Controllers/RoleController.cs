﻿using company.Web.Models;
using Company.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace company.Web.Controllers
{
    [Authorize(Roles = "theleader")]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<IdentityRole> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,ILogger<IdentityRole> logger,UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _logger = logger;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await  _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded) { return RedirectToAction("Index"); }
                foreach (var item  in result.Errors) { _logger.LogError(item.Description); }
            }
            
            return View(role);
        }

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null)
                return NotFound();
            if (viewName == "Update")
            {
                var roleViewModel = new RoleUpdateViewModel { Id = role.Id, Name = role.Name };
                return View(viewName, roleViewModel);
            }

            return View(viewName, role);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, RoleUpdateViewModel roleModel)
        {
            if (id != roleModel.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    if (role is null)
                        return NotFound();
                    role.Name = roleModel.Name;
                    role.NormalizedName = roleModel.Name.ToUpper(); //another edit will be done  around min 45 / 50 / 55
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded) { _logger.LogInformation("role Updated"); return RedirectToAction("Index"); }
                    foreach (var item in result.Errors) { _logger.LogError(item.Description); }
                }
                catch (Exception ex) { _logger.LogError(ex.Message); }
                return RedirectToAction("Index");
            }

            return View(roleModel);
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role is null)
                    return NotFound();
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded) { return RedirectToAction("Index"); }
                foreach (var item in result.Errors) { _logger.LogError(item.Description); }


            }
            catch (Exception ex) { _logger.LogError(ex.Message); }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddOrRemoveUsers(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
                return NotFound();

            ViewBag.RoleId = roleId;

            var users = await _userManager.Users.ToListAsync();

            var usersInRole = new List<UserInroleViewModel>();
            foreach (var user in users)
            {
                var userInRole = new UserInroleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userInRole.IsSelected = true;
                else
                    userInRole.IsSelected = false;

                usersInRole.Add(userInRole);
            }
            return View(usersInRole);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUsers(string roleId, List<UserInroleViewModel> users)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
                return NotFound();


            if (ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    var appUser = await _userManager.FindByIdAsync(user.UserId);
                    if (appUser is not null)
                    {
                        if (user.IsSelected && !await _userManager.IsInRoleAsync(appUser, role.Name))
                            await _userManager.AddToRoleAsync(appUser, role.Name);
                        else if (!user.IsSelected && await _userManager.IsInRoleAsync(appUser, role.Name))
                            await _userManager.RemoveFromRoleAsync(appUser, role.Name);
                    }
                }
                return RedirectToAction("Update", new { id = roleId });
            }

            return View(users);
        }

    }
}
