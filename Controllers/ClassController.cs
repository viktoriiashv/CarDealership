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
    [Route("api/classes")]
    public class ClassController : Controller
    {
        private ClassService classService;
        public ClassController(ClassService classService)
        {
            this.classService = classService;
        }
        [HttpGet]
        public List<Class> GetClasses()
        {
            return classService.GetClassesList();
        }

        [HttpGet("{id}")]
        public Class GetClassById(int id)
        {
            return classService.GetClassById(id);
        }

        [HttpPost]
        public Class PostClass(Class myclass)
        {
            return classService.AddClass(myclass);
        }

        [HttpDelete("{id}")]
        public Class DeleteClass(int id)
        {
            return classService.DeleteClass(id);
        }

        [HttpPatch("{id}")]
        public Class PatchClass(int id, [FromBody] Class body)
        {
            return classService.EditClass(id, body);
        }
    }
}
