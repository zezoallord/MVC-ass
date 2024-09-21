using company.Web.Models;
using Company.Data.Models;
using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace company.Web.Controllers
{
    [Authorize(Roles = "theleader")]

    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public UserController(UserManager<ApplicationUser> userManager,ILogger<UserController> logger)
        {
           _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index(string serchInp)
        {
            List<ApplicationUser> users;
            if(string.IsNullOrEmpty(serchInp))
                users = await _userManager.Users.ToListAsync();
            else
                users = await _userManager.Users.Where(user => user.NormalizedUserName.Contains(serchInp.Trim().ToUpper())).ToListAsync();

            return View(users);
        }
        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
                return NotFound();
            if (viewName == "Update")
            {
                var userViewModel = new UserUpdateViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                return View(viewName, userViewModel);
            }

            return View(viewName, user);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, UserUpdateViewModel applecationuser)
        {
            if (id != applecationuser.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);

                    if (user is null)
                        return NotFound();

                    user.UserName = applecationuser.UserName;
                    user.NormalizedUserName = applecationuser.UserName.ToUpper();

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User updated successfully");
                        return RedirectToAction("Index");
                    }
                    foreach (var error in result.Errors)
                        _logger.LogError(error.Description);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(applecationuser);
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user is null)
                    return NotFound();
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) { return RedirectToAction("Index"); }
                foreach (var item in result.Errors) { _logger.LogError(item.Description); }

        
            }
            catch (Exception ex) { _logger.LogError(ex.Message); }
            return RedirectToAction("Index");
        }
    }
}
