using Mango.Services.ProductApi.Models.Dto;
using Mango.Services.ProductApi.Repository;
using Mango.web.Services.ProductApi;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductApi.Controllers
{
    [Route("api/products")]
    public class ProductApiController : Controller
    {
        private IProductRepository _productRepository;

        protected ResponseDto _response;

        public ProductApiController(IProductRepository repository)
        {
            _productRepository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> products = await _productRepository.GetProducts();
                _response.Result = products;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.ToString() };
            }

            return _response;
        }

    }
}
