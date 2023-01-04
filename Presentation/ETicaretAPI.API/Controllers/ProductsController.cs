using System.Net;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParamaters;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Application.ViewModels.Products;
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
        private readonly IFileService _fileService;
        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IFileReadRepository _fileReadRepository;
        private readonly IProductImageFileWriteRepository _imageFileWriteRepository;
        private readonly IProductImageFileReadRepository _imageFileReadRepository;
        private readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        private readonly IInvoiceFileReadRepository _invoiceFileReadRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IFileService fileService, IFileWriteRepository fileWriteRepository, IFileReadRepository fileReadRepository, IProductImageFileWriteRepository imageFileWriteRepository, IProductImageFileReadRepository imageFileReadRepository, IInvoiceFileWriteRepository invoiceFileWriteRepository, IInvoiceFileReadRepository invoiceFileReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;

            _fileService = fileService;
            _fileWriteRepository = fileWriteRepository;
            _fileReadRepository = fileReadRepository;
            _imageFileWriteRepository = imageFileWriteRepository;
            _imageFileReadRepository = imageFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(x => new
            {
                x.Id,
                x.Name,
                x.Stock,
                x.Price,
                x.CreatedDate,
                x.UpdatedDate
            });
            return Ok(new
            {
                totalCount,
                products
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {

            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]

        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok(200);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var datas = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
            await _imageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            {
                FileName = d.fileName,
                Path = d.path
            }).ToList());
            await _productWriteRepository.SaveAsync();

            return Ok();
        }

    }
}




