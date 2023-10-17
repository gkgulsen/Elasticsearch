using Elasticsearch.API.ViewModels.Product;
using Elasticsearch.API.ViewModels;
using Elasticsearch.API.Models.Product;
using System.Collections.Immutable;

namespace Elasticsearch.API.Services
{
    public interface IProductServices
    {
        Task<ResponseViewModel<ProductViewModel>> SaveAsync(ProductCreateViewModel request);
        Task<ResponseViewModel<List<ProductViewModel>>> GetAllAsync();
        Task<ResponseViewModel<ProductViewModel>> GetById(string id);
        Task<ResponseViewModel<bool>> UpdateAsync(ProductUpdateViewModel productUpdateViewModel);
        Task<ResponseViewModel<bool>> DeleteAsync(string id);
    }
}
