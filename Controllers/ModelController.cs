using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealership.Services;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("api/models")]
    public class ModelController : Controller
    {
        private ModelService modelService;
        public ModelController(ModelService modelService)
        {
            this.modelService = modelService;
        }
        [HttpGet]
        public List<Model> GetModels()
        {
            return modelService.GetModelsList();
        }

        [HttpGet("{id}")]
        public Model GetModelById(int id)
        {
            return modelService.GetModelById(id);
        }

        [HttpPost]
        public Model PostModel(Model model)
        {
            return modelService.AddModel(model);
        }

        [HttpDelete("{id}")]
        public Model DeleteModel(int id)
        {
            return modelService.DeleteModel(id);
        }

        [HttpPatch("{id}")]
        public Model PatchModel(int id, [FromBody] Model body)
        {
            return modelService.EditModel(id, body);
        }
    }
}
