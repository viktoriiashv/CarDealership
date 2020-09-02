using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarDealership.Services;
using CarDealership.Models;
namespace CarDealership.Controllers
{
    public class ManagerController : Controller
    {
        private ManagerService managerService;
        public ManagerController(ManagerService managerService)
        {
            this.managerService = managerService;
        }
        [HttpGet("managers")]
        public List<Manager> GetManagers()
        {
            Console.WriteLine(managerService.GetManagersList());
            return managerService.GetManagersList();
        }
    }
}
