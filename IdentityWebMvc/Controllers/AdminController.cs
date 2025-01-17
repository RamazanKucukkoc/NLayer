﻿using IdentityWebMvc.Models;
using IdentityWebMvc.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IdentityWebMvc.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager = null) : base(userManager, null, roleManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RoleCreate(RoleViewModel roleViewModel)
        {
            AppRole role=new AppRole();
            role.Name = roleViewModel.Name;
            IdentityResult result=roleManager.CreateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            else
            {
                AddModelError(result);
            }
            return View(roleViewModel);
        }

        public IActionResult Roles()
        {
            return View(roleManager.Roles.ToList());
        }
        public IActionResult Users()
        {
            return View(userManager.Users.ToList());
        }
        public IActionResult RoleDelete(string id)
        {
            AppRole role = roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                IdentityResult result = roleManager.DeleteAsync(role).Result;
            }
            return RedirectToAction("Roles");
        }
        public IActionResult RoleUpdate(string id)
        {
            AppRole role = roleManager.FindByIdAsync(id).Result;


            if (role!=null)
            { 
                return View(role.Adapt<RoleViewModel>());
                
            }
           return RedirectToAction("Roles");
        }

        [HttpPost]
        public IActionResult RoleUpdate(RoleViewModel roleViewModel)
        {
            AppRole role = roleManager.FindByIdAsync(roleViewModel.Id).Result;
            if (role!=null)
            {
                role.Name = roleViewModel.Name;
                IdentityResult result =roleManager.UpdateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                else
                {
                    AddModelError(result);
                }
            }
            else
            {
                ModelState.AddModelError("","Güncelleme işlemi başarısız oldu.");
            }
            return View(roleViewModel);
        }
    }
}
