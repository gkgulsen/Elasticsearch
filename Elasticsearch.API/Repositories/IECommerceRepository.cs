using Elasticsearch.API.Models.ECommerceModel;
using System.Collections.Immutable;

namespace Elasticsearch.API.Repositories
{
    public interface IECommerceRepository
    {
        Task<ImmutableList<ECommerce>> TermQueryAsync(string customerFirstName);
        Task<ImmutableList<ECommerce>> TermsQueryAsync(List<string> customerFirstNameList);
        Task<ImmutableList<ECommerce>> PrefixQueryAsync(string customerFullName);
        Task<ImmutableList<ECommerce>> RangeQueryAsync(double fromPrice, double toPrice);
        Task<ImmutableList<ECommerce>> MatchAllQueryAsync();
        Task<ImmutableList<ECommerce>> PaginationQueryAsync(int page, int pageSize);
        Task<ImmutableList<ECommerce>> WildCardQueryAsync(string customerFullName);
        Task<ImmutableList<ECommerce>> FuzzyQueryAsync(string customerName);
        Task<ImmutableList<ECommerce>> MatchQueryFullTextAsync(string categoryName);
        Task<ImmutableList<ECommerce>> MatchBoolPrefixQueryFullTextAsync(string customerFullName);
        Task<ImmutableList<ECommerce>> MatchPhraseQueryFullTextAsync(string customerFullName);
        Task<ImmutableList<ECommerce>> CompoundQueryAsync(string cityName, double taxfulTotalPrice, string categoryName, string manufacturer);
        Task<ImmutableList<ECommerce>> CompoundQueryTwoAsync(string customerFullName);
        Task<ImmutableList<ECommerce>> MultiMatchQueryFullTextAsync(string name);
    }
}
