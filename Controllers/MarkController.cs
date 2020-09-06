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
    [Route("api/marks")]
    public class MarkController : Controller
    {
        private MarkService markService;
        public MarkController(MarkService markService)
        {
            this.markService = markService;
        }
        [HttpGet]
        public List<Mark> GetMarks()
        {
            return markService.GetMarkList();
        }

        [HttpGet("{id}")]
        public Mark GetMarkById(int id)
        {
            return markService.GetMarkById(id);
        }

        [HttpPost]
        public Mark PostMark(Mark mark)
        {
            return markService.AddMark(mark);
        }

        [HttpDelete("{id}")]
        public Mark DeleteMark(int id)
        {
            return markService.DeleteMark(id);
        }

        [HttpPatch("{id}")]
        public Mark PatchMark(int id, [FromBody] Mark body)
        {
            return markService.EditMark(id, body);
        }
    }
}
