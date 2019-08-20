using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFitness.Models;
using CoreFitness.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Controllers
{
    [Authorize (Roles="admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager,
                                UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // ROLES

        // Display create role form
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        //Create a new role
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {

            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("listallroles", "admin");
                }


                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        // Display a list of all roles
        [HttpGet]
        public IActionResult ListAllRoles()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }

        // Display edit role form
        [HttpGet]
        public async Task<IActionResult> EditRole (string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {id} does not exist";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }                
               
            }

            return View(model);
        }

        // Display edit role form
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {model.Id} does not exist";
                return View("NotFound");
            }

            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListAllRoles");
                }

                // Loop through each error and add each error description to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }


        }

        // Display EditRoleUsers Form
        [HttpGet]
        public async Task<IActionResult> EditRoleUsers (string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            // Loop through users and display
            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                // Check if user has already been assigned the role
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        // Post changes to role
        [HttpPost]
        public async Task<IActionResult> EditRoleUsers(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                // If user is selected and is not already a member of the role 
                // Add the user
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                // If user is not selected is already a member of the role
                // Remove the user
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        // Delete a role
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            // Display not found view if the role can not be found
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            // If the role with Id exists in the database delete that role
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListAllRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListAllRoles");
            }
        }

        //USERS

        // Display list of all users 
        [HttpGet]
        public IActionResult ListAllUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        // Display edit user view
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            // Get user roles
            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                Roles = userRoles
            };

            return View(model);
        }

        // Post changes to the user
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Name = model.Name;
                user.Surname = model.Surname;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListAllUsers");
                }
                // Loop through all the errors and display them in the view
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        // Delete user
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListAllUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListAllUsers");
            }
        }


        // Display manage user roles view 
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        // Apply changes to user roles
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
            {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }



    }
}