using Elastic.Clients.Elasticsearch;
using Elasticsearch.API.Repositories;
using Elasticsearch.API.ViewModels;
using Elasticsearch.API.ViewModels.Product;
using System.Net;

namespace Elasticsearch.API.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductServices> _logger;

        public ProductServices(IProductRepository productRepository, ILogger<ProductServices> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ResponseViewModel<List<ProductViewModel>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productListViewModel = new List<ProductViewModel>();

            foreach (var x in products)
            {

                if (x.Feature is null)
                {
                    productListViewModel.Add(new ProductViewModel(x.Id, x.Name, x.Price, x.Stock, null));

                    continue;

                }


                productListViewModel.Add(new ProductViewModel(x.Id, x.Name, x.Price, x.Stock,
                    new ProductFeatureViewModel(x.Feature!.Width, x.Feature!.Height, x.Feature.Color.ToString())));

            }



            return ResponseViewModel<List<ProductViewModel>>.Success(productListViewModel, HttpStatusCode.OK);
        }

        public async Task<ResponseViewModel<ProductViewModel>> GetById(string id)
        {
            var hasProduct = await _productRepository.GetById(id);

            if (hasProduct == null)
            {
                return ResponseViewModel<ProductViewModel>.Fail("Product not found", HttpStatusCode.NotFound);
            }

            return ResponseViewModel<ProductViewModel>.Success(hasProduct.CreateViewModel(), HttpStatusCode.OK);
        }

        public async Task<ResponseViewModel<ProductViewModel>> SaveAsync(ProductCreateViewModel request)
        {
            var response = await _productRepository.SaveAsync(request.CreateProduct());

            if (response == null)
                return ResponseViewModel<ProductViewModel>.Fail(new List<string> { "An error occurred during registration" }, HttpStatusCode.InternalServerError);

            return ResponseViewModel<ProductViewModel>.Success(response.CreateViewModel(), HttpStatusCode.Created);
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(ProductUpdateViewModel productUpdateViewModel)
        {
            var isSuccess= await _productRepository.UpdateAsync(productUpdateViewModel);

            if (!isSuccess)
            {
                return ResponseViewModel<bool>.Fail("An error occurred during updating", HttpStatusCode.InternalServerError);
            }

            return ResponseViewModel<bool>.Success(true, HttpStatusCode.NoContent);
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(string id)
        {
            var deleteResponse = await _productRepository.DeleteAsync(id);


            if (!deleteResponse.IsValidResponse && deleteResponse.Result == Result.NotFound)
            {
                return ResponseViewModel<bool>.Fail(new List<string> { "The product you tried to delete was not found." }, System.Net.HttpStatusCode.NotFound);

            }


            if (!deleteResponse.IsValidResponse)
            {                
                deleteResponse.TryGetOriginalException(out Exception? originalException);
                _logger.LogError(originalException, deleteResponse.ElasticsearchServerError?.Error.ToString());


                return ResponseViewModel<bool>.Fail(new List<string> { "An error occurred during deleting" }, System.Net.HttpStatusCode.InternalServerError);

            }


            return ResponseViewModel<bool>.Success(true, HttpStatusCode.NoContent);
        }
    }
}
