using cw5.Model;
using cw5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace cw5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IProductService _dbProducts;
        public WarehousesController(IProductService dbProduct)
        {
            _dbProducts = dbProduct;
        }
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto value)
        {
            var context = new ProductService();
            try
            { 
                if (value.Amount < 0)
                { 
                
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Wprowadzono błędne zamówienie");
            }
            return Ok("Dodano nowe zamówienie");
        }
    }

}
