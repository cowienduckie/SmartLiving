﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartLiving.DeviceMVC.BussinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Entities.Models;
using System.Diagnostics;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = _userRepository.GetAll();

            return View();
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