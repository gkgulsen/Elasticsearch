using Elasticsearch.API.Services;
using Elasticsearch.API.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateViewModel requst)
        {

            return CreateActionResult(await _services.SaveAsync(requst));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _services.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {

            return CreateActionResult(await _services.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateViewModel productUpdateViewModel)
        {

            return CreateActionResult(await _services.UpdateAsync(productUpdateViewModel));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {

            return CreateActionResult(await _services.DeleteAsync(id));
        }
    }
}
