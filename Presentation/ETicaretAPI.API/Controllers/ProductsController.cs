using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
          Product product=  await _productReadRepository.GetByIdAsync("4a6e25ea-d9d5-42ae-ad90-51d49f20730c",false);
          product.Name = "Mehmet";
          _productWriteRepository.SaveAsync();

            
          //await _productWriteRepository.AddRangeAsync(new()
          //{
          //    new() { Id = Guid.NewGuid(), Name = "Product 7", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
          //    new() { Id = Guid.NewGuid(), Name = "Product 8", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
          //    new() { Id = Guid.NewGuid(), Name = "Product 9", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30 }
          //});

          //await _productWriteRepository.SaveAsync();


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
