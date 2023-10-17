using Elastic.Clients.Elasticsearch;
using Elasticsearch.API.Models.ECommerceModel;
using System.Collections.Immutable;

namespace Elasticsearch.API.Helper
{
    public record class Elastichelper
    {
        public static ImmutableList<ECommerce> ReturnToImmutableListWithId(SearchResponse<ECommerce> result)
        {
            foreach (var hit in result.Hits)            
                hit.Source.Id = hit.Id;

            return result.Documents.ToImmutableList();
        }
    }
}
