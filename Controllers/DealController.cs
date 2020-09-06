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
        public List<Deal> GetDeals()
        {
            return dealService.GetDealList();
        }
        [HttpPost]
        public Deal PostDeal(Deal deal)
        {
            return dealService.AddDeal(deal);
        }

        [HttpGet("{id}")]
        public Deal GetDealById(int id)
        {
            return dealService.GetDealByID(id);
        }

        [HttpDelete("{id}")]
        public Deal DeleteDeal(int id)
        {
            return dealService.DeleteDeal(id);
        }

        [HttpPatch("{id}")]
        public Deal PatchDeal(int id, [FromBody] Deal body)
        {
            return dealService.EditDeal(id, body);
        }
    }
}
