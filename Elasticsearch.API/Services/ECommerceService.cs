using Elasticsearch.API.Models.ECommerceModel;
using Elasticsearch.API.Repositories;
using System.Collections.Immutable;

namespace Elasticsearch.API.Services
{
    public class ECommerceService : IECommerceService
    {
        private readonly IECommerceRepository _repository;

        public ECommerceService(IECommerceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImmutableList<ECommerce>> TermQueryAsync(string customerFirstName)
        {
            return await _repository.TermQueryAsync(customerFirstName);
        }
                
        public async Task<ImmutableList<ECommerce>> TermsQueryAsync(List<string> customerFirstNameList)
        {
            return await _repository.TermsQueryAsync(customerFirstNameList);
        }
                
        public async Task<ImmutableList<ECommerce>> PrefixQueryAsync(string customerFullName)
        {
            return await _repository.PrefixQueryAsync(customerFullName);
        }
                
        public async Task<ImmutableList<ECommerce>> RangeQueryAsync(double fromPrice, double toPrice)
        {
            return await _repository.RangeQueryAsync(fromPrice, toPrice);
        }
                
        public async Task<ImmutableList<ECommerce>> MatchAllQueryAsync()
        {
            return await _repository.MatchAllQueryAsync();
        }
                
        public async Task<ImmutableList<ECommerce>> PaginationQueryAsync(int page, int pageSize)
        {
            return await _repository.PaginationQueryAsync(page, pageSize);
        }
                
        public async Task<ImmutableList<ECommerce>> WildCardQueryAsync(string customerFullName)
        {
            return await _repository.WildCardQueryAsync(customerFullName);
        }
                
        public async Task<ImmutableList<ECommerce>> FuzzyQueryAsync(string customerName)
        {
            return await _repository.FuzzyQueryAsync(customerName);
        }
                
        public async Task<ImmutableList<ECommerce>> MatchQueryFullTextAsync(string categoryName)
        {
            return await _repository.MatchQueryFullTextAsync(categoryName);
        }
                
        public async Task<ImmutableList<ECommerce>> MatchBoolPrefixQueryFullTextAsync(string customerFullName)
        {
            return await _repository.MatchBoolPrefixQueryFullTextAsync(customerFullName);
        }

        public async Task<ImmutableList<ECommerce>> MatchPhraseQueryFullTextAsync(string customerFullName)
        {
            return await _repository.MatchPhraseQueryFullTextAsync(customerFullName);
        }
        public async Task<ImmutableList<ECommerce>> CompoundQueryAsync(string cityName, double taxfulTotalPrice, string categoryName, string manufacturer)
        {
            return await _repository.CompoundQueryAsync(cityName, taxfulTotalPrice, categoryName, manufacturer);
        }

        public async Task<ImmutableList<ECommerce>> CompoundQueryTwoAsync(string customerFullName)
        {
            return await _repository.CompoundQueryTwoAsync(customerFullName);
        }

        public async Task<ImmutableList<ECommerce>> MultiMatchQueryFullTextAsync(string name)
        {
            return await _repository.MultiMatchQueryFullTextAsync(name);
        }
    }
}
