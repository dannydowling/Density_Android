using DensityServer.ModelsandRepositories.User;
using DensityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.Controllers
{
    public class UserRegistrationController : Controller
    {

        private UserService _userService;

        [HttpPost]
        // GET: UserRegistrationController
        public async Task<ActionResult> Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(userModel);
                return RedirectToAction(nameof(EmailConfirmation), new { userModel.Email });
            }
            else
            {
                return View(userModel);
            }
        }

        [HttpGet]
        // GET: UserRegistrationController/EmailConfirmation/{email}
        public async Task<ActionResult> EmailConfirmation(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user?.IsEmailConfirmed == true)
            {
                return RedirectToAction("Index", "GameInvitation", new { email = email });
            }

            ViewBag.Email = email;
            user.IsEmailConfirmed = true;
            user.EmailConfirmationDate = DateTime.Now;
            await _userService.UpdateUser(user);
            return View();
        }

        // GET: UserRegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
