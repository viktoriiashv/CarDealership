using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealership.Models;
using CarDealership.Services;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : Controller
    {
        private CarService carService;
        public CarController(CarService carService)
        {
            this.carService = carService;
        }
        [HttpGet]
        public List<Car> GetCars()
        {
            return carService.GetCarsList();
        }
    }
}
