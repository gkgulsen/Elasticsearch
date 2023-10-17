using Elastic.Clients.Elasticsearch;
using Elasticsearch.API.Models.Product;
using Elasticsearch.API.ViewModels.Product;
using System.Collections.Immutable;

namespace Elasticsearch.API.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> SaveAsync(Product newProduct);
        Task<ImmutableList<Product>> GetAllAsync();
        Task<Product?> GetById(string  id);
        Task<bool> UpdateAsync(ProductUpdateViewModel productUpdateViewModel);
        Task<DeleteResponse> DeleteAsync(string id);
    }
}
