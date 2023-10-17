using Elasticsearch.API.ViewModels.Product;

namespace Elasticsearch.API.Models.Product
{
    public class Product
    {    
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ProductFeature? Feature { get; set; }


        public ProductViewModel CreateViewModel()
        {
            if (Feature == null)
                return new ProductViewModel(Id, Name, Price, Stock, null);

            return new ProductViewModel(Id, Name, Price, Stock, new ProductFeatureViewModel(Feature.Width, Feature.Height, Feature.Color.ToString()));

        }
    }
}
