using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TracyShop.Data;
using TracyShop.Models;
using TracyShop.Repository;
using TracyShop.ViewModels;

namespace TracyShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfilesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILoginRepository _loginRepository;
        private readonly UserManager<AppUser> _userManager;
        private IHostingEnvironment _hostingEnvironment;

        public ProfilesController(ILoginRepository loginRepository, UserManager<AppUser> userManager,
            AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _loginRepository = loginRepository;
            _userManager = userManager;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult Profiles()
        {
            var userid = _userManager.GetUserId(HttpContext.User);

            if (userid == null) return RedirectToAction("Login", "Login");

            var user = _userManager.FindByIdAsync(userid).Result;
            var profile = new ProfileModel();
            profile.Name = user.Name;
            profile.UserName = user.UserName;
            profile.Email = user.Email;
            profile.Birthday = user.Birthday;
            profile.PhoneNumber = user.PhoneNumber;
            profile.Gender = user.Gender;
            profile.AvatarPath = null;
            return View(profile);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Profiles(ProfileModel userdetails)
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            var user = _userManager.FindByIdAsync(userid).Result;

            var wwwRootPath = _hostingEnvironment.WebRootPath;
            var fileName = Path.GetFileNameWithoutExtension(userdetails.AvatarPath.FileName);
            var extension = Path.GetExtension(userdetails.AvatarPath.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            var filePath = Path.Combine(wwwRootPath + "/Admin/img/avatar/", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await userdetails.AvatarPath.CopyToAsync(fileStream);
            }

            user.Name = userdetails.Name;
            user.PhoneNumber = userdetails.PhoneNumber;
            user.Gender = userdetails.Gender;
            user.Birthday = userdetails.Birthday;
            user.Avatar = "/Admin/img/avatar/" + fileName;

            userdetails.Email = user.Email;
            userdetails.UserName = user.UserName;
            var x = await _userManager.UpdateAsync(user);
            if (x.Succeeded)
            {
                ViewBag.Message = "Update user information successed.";
                return View("profiles", userdetails);
            }

            ViewBag.Message = "Update user information failed.";
            return View(userdetails);
        }
    }
}