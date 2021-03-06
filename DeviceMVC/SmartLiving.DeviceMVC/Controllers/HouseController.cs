using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data.Models;
using System;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseRepository _houseRepository;

        public HouseController(
            IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        // GET: House
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: House/Detail/id
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var item = _houseRepository.GetById(id);

                if (item == null)
                    item = new HouseModel();

                return View(item);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
