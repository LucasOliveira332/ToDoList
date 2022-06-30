﻿using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Entities;

namespace ToDoList.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            User userValid = _userRepository.UserValidation(user);

            if(userValid != null){
                user = new User() { Id = userValid.Id };
                user.Id = userValid.Id;
                return RedirectToAction("Index","Home", user);
            }

            return View(user);
        }
    }
}
