using Logic.DTO;
using Logic.Interfaces;
using Logic.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserLogic _userLogic;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(IUserLogic userLogic, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userLogic = userLogic;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        public async Task<IActionResult> RegisterPost(AppUserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                userDto.Role = "REGULAR";
                userDto.Devices = new List<DeviceDTO>();
                var user = userDto.FromDTO();
                user.SecurityStamp = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.FirstName));
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, user.Role.ToString()));
                    user.EmailConfirmed = true;
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> SignIn(AppUserDTO userDTO)
        {
            await _signInManager.SignOutAsync();
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userDTO.Username);
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, user.Role.ToString()));
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Login");
        }
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<IActionResult> Index()
        {
            var users = await _userLogic.GetAll();
            return View(users);
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost,ActionName("Create")]
        public async Task<IActionResult> CreateUser(AppUserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                userDto.Role = "REGULAR";
                userDto.Devices = new List<DeviceDTO>();
                var user = userDto.FromDTO();
                user.SecurityStamp = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userLogic.GetById(id);
            return View(user);
        }

        public async Task<IActionResult> EditPost(AppUserDTO user)
        {
            await _userLogic.Update(user);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userLogic.GetById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var userDto = await _userLogic.GetById(id);
            await _userLogic.Remove(userDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Chat(Guid id)
        {
            var user = await _userLogic.GetById(id);
            return View("UserChat",user);
        }

    }
}
