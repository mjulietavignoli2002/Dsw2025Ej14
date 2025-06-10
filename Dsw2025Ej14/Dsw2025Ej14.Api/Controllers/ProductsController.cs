using Dsw2025Ej14.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api/products")]

    public class ProductsController : ControllerBase
    {
        private readonly IPersistencia _persistenciaEnMemoria;

        public ProductsController(IPersistencia persistenciaEnMemoria)
        {
            _persistenciaEnMemoria = persistenciaEnMemoria;
        }

        [HttpGet()]

        public IActionResult GetProducts()
        {
            return Ok(_persistenciaEnMemoria.GetProducts());
        }

        [HttpGet("{sku}")]

        public IActionResult GetProduct(string sku)
        {
            var product = _persistenciaEnMemoria.GetProduct(sku);
            if(product == null) return NotFound();
            return Ok(_persistenciaEnMemoria.GetProduct(sku));
        }

        
    }
}
