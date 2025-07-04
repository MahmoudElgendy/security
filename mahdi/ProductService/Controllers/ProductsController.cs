using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using productservice.Models;
using System.Security.Claims;

namespace productservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<IEnumerable<productservice.Models.Product>> GetProducts()
        {
            return Ok(GetProductsList());
        }

        [HttpGet("{id}")]
        //[Authorize]
        [Authorize(AuthenticationSchemes = "Basic")]
        public ActionResult<IEnumerable<productservice.Models.Product>> GetProduct()
        {
            return Ok(GetProductsList());
        }

        private List<Product> GetProductsList()
        {
            var userName = User.Identity.Name;
            var userId = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return new List<productservice.Models.Product>
            {
                new productservice.Models.Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 10.99M , CreatedBy=userName},
                new productservice.Models.Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 20.99M , CreatedBy=userName},
                new productservice.Models.Product { Id = Guid.NewGuid(), Name = "Product 3", Price = 30.99M , CreatedBy=userName}
            };
        }
    }
}
