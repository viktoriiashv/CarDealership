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
    [Route("api/deals")]
    public class DealController : Controller
    {
        private DealService dealService;
        public DealController(DealService dealService)
        {
            this.dealService = dealService;
        }
        [HttpGet]
        public List<Deal> GetCars()
        {
            return dealService.GetDealList();
        }
        [HttpPost]
        public Deal AddDeal(Deal deal)
        {
            return dealService.AddDeal(deal);
        }
    }
}
