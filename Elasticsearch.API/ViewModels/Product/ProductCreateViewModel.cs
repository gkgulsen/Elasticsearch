using Elasticsearch.API.Models.Enums;
using P = Elasticsearch.API.Models.Product;
namespace Elasticsearch.API.ViewModels.Product
{
    public record ProductCreateViewModel(string Name, decimal Price, int Stock, ProductFeatureViewModel Feature)
    {
        public P.Product CreateProduct()
        {
            return new P.Product
            {
                Name = Name,
                Price = Price,
                Stock = Stock,
                Feature = new P.ProductFeature()
                {
                    Width = Feature.Width,
                    Height = Feature.Height,
                    Color = (EColor)int.Parse(Feature.Color)
                }
            };
        }
    }
}
