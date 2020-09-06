﻿using System;
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

        [HttpGet("{id}")]
        public Car GetCarById(int id)
        {
            return carService.GetCarById(id);
        }

        [HttpPost]
        public Car PostCar(Car car)
        {
            return carService.AddCar(car);
        }

        [HttpDelete("{id}")]
        public Car DeleteCar(int id)
        {
            return carService.DeleteCar(id);
        }

        [HttpPatch("{id}")]
        public Car PatchCar(int id, [FromBody] Car body)
        {
            return carService.EditCar(id, body);
        }
    }
}
