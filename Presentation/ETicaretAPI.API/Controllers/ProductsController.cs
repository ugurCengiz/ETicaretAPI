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

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Merhaba");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("add")]
        public async Task Add()
        {
            var customerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "muiddinn" });

            await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "İstanbul,Zeytinburnu",CustomerId = customerId});
            await _orderWriteRepository.SaveAsync();
        }

    }
}




//[HttpGet]
//public async Task GetTracking()
//{
//  Product product=  await _productReadRepository.GetByIdAsync("4a6e25ea-d9d5-42ae-ad90-51d49f20730c",false);
//  product.Name = "Mehmet";
//  _productWriteRepository.SaveAsync();


//  //await _productWriteRepository.AddRangeAsync(new()
//  //{
//  //    new() { Id = Guid.NewGuid(), Name = "Product 7", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
//  //    new() { Id = Guid.NewGuid(), Name = "Product 8", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
//  //    new() { Id = Guid.NewGuid(), Name = "Product 9", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30 }
//  //});

//  //await _productWriteRepository.SaveAsync();


//}
