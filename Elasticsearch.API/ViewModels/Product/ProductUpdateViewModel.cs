namespace Elasticsearch.API.ViewModels.Product
{
    public record ProductUpdateViewModel(string id, string Name, decimal Price, int Stock, ProductFeatureViewModel Feature)
    {
    }
}
