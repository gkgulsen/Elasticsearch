namespace Elasticsearch.API.ViewModels.Product
{
    public record ProductViewModel(string Id, string Name, decimal Price, int Stock,  ProductFeatureViewModel? Feature)
    {        
    }
}
