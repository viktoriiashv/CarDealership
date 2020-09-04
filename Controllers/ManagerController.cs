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
    [ApiController]
    [Route("api/managers")]
    public class ManagerController : Controller
    {
        private ManagerService managerService;
        public ManagerController(ManagerService managerService)
        {
            this.managerService = managerService;
        }
        [HttpGet]
        public List<Manager> GetManagers()
        {
            return managerService.GetManagersList();
        }
        [HttpGet("best/count")]
        public Manager GetBestCountManagers(DateTime startDate, DateTime endDate)
        {
            return managerService.GetMaxCountDealManager(startDate, endDate);
        }

        [HttpGet("bestseller/mark/bysum")]
        public List<Tuple<Manager, Mark>> GetManagerBestsellerMarkBySum()
        {
            return managerService.GetManagerBestsellerMarkBySum();
        }

        [HttpGet("bestseller/mark/bycount")]
        public List<Tuple<Manager, Mark>> GetManagerBestsellerMarkByCount()
        {
            return managerService.GetManagerBestsellerMarkByCount();
        }

    }
}
