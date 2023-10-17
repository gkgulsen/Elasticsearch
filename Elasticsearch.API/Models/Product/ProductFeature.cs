using Elasticsearch.API.Models.Enums;

namespace Elasticsearch.API.Models.Product
{
    public class ProductFeature
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public EColor Color { get; set; }
    }
}
