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
                if (value.Amount < 0) return BadRequest("Suma mniejsza od zera");
                var ifNotExistsWarehouse = context.GetWarehouse(value.IdWarehouse).Count() == 0;
                if (ifNotExistsWarehouse) return BadRequest("Wprowadzono błędny magazyn");
                var ifNotExistsProduct = context.GetWarehouse(value.IdProduct).Count() == 0;
                if (ifNotExistsProduct) return BadRequest("Wprowadzono błędny produkt");
                var ifValidOrder = context.CheckOrder(value);
                if (ifValidOrder == 0) return BadRequest("Błąd zamówienia");
                var ifOrderExist = context.CheckOrderExists(ifValidOrder);
                if (ifOrderExist) return BadRequest("Zlecenie już zrealizowane");
                context.UpdateOrderDate(ifValidOrder);
                int idMainKey = context.InsertOrder(value, ifValidOrder);
                return Ok(idMainKey);
            }
            catch (Exception ex)
            {
                return BadRequest("Wprowadzono błędne zamówienie");
            }
        }
    }

}
