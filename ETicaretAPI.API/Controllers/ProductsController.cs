using ETicaretAPI.Application.Repositories.ProductRepository;
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

            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name="Ürün -1",Price=20,Stock=10},
            //    new() {Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name="Ürün -1",Price=50,Stock=30},
            //    new() {Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name="Ürün -1",Price=60,Stock=40},
            //    new() {Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name="Ürün -1",Price=80,Stock=50}
            //});
            //var count = await _productWriteRepository.SaveAsync();


            // tracking parametresi false olduğu zaman veritabanına işlemler yansımaz.
            Product product =  await _productReadRepository.GetByIdAsync("46771d10-1de0-4246-ab08-0338774800f5",false);
            product.Name = "Test Malzeme-1111";
            await _productWriteRepository.SaveAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
