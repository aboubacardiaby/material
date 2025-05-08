using Material.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace material.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        // Temporary in-memory data store for demonstration
        private static readonly List<MaterialEntity> materials = new List<MaterialEntity>
        {
            new MaterialEntity { Id = 1, Name = "Material 1", Description = "Description for Material 1" },
            new MaterialEntity { Id = 2, Name = "Material 2", Description = "Description for Material 2" }
        };

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<MaterialEntity>> GetAll()
        {
            return Ok(materials);
        }
    }
}