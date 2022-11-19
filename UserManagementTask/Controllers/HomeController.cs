using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagementTask.Areas.Identity.Data;
using UserManagementTask.Models;

namespace UserManagementTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Block(List<ApplicationUser> users, string[] ids)
        {
            foreach (string userId in ids)
            {
                var user = await _userManager.FindByIdAsync(userId);
                user.Status = Status.Blocked;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Unblock(List<ApplicationUser> users, string[] ids)
        {
            foreach (string userId in ids)
            {
                var user = await _userManager.FindByIdAsync(userId);
                user.Status = Status.Active;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(List<ApplicationUser> users, string[] ids)
        {
            foreach (string userId in ids)
            {
                var user = await _userManager.FindByIdAsync(userId);
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}