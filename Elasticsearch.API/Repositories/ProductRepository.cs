﻿using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elasticsearch.API.Models.Enums;
using Elasticsearch.API.Models.Product;
using Elasticsearch.API.ViewModels.Product;
using System.Collections.Immutable;

namespace Elasticsearch.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElasticsearchClient _client;
        private const string indexName = "products";

        public ProductRepository(ElasticsearchClient client)
        {
            _client = client;
        }

        public async Task<Product?> SaveAsync(Product newProduct)
        {
            newProduct.Created = DateTime.Now;

            var response = await _client.IndexAsync(newProduct, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            if (!response.IsSuccess()) return null;

            newProduct.Id = response.Id;

            return newProduct;


        }

        public async Task<ImmutableList<Product>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Product>(s =>
                            s.Index(indexName)
                                .Query(q =>
                                    q.MatchAll()));

            foreach (var hit in result.Hits) hit.Source.Id = hit.Id;

            return result.Documents.ToImmutableList();
        }

        public async Task<Product?> GetById(string id)
        {
            var response = await _client.GetAsync<Product>(id, x => x.Index(indexName));

            //fast fail
            if (!response.IsSuccess())
            {
                return null;
            }

            response.Source.Id= response.Id;

            return response.Source;
        }

        public async Task<bool> UpdateAsync(ProductUpdateViewModel productUpdateViewModel)
        {
            var response=await _client.UpdateAsync<Product,ProductUpdateViewModel>(indexName, productUpdateViewModel.id,x=>x.Doc(productUpdateViewModel));

            return response.IsSuccess();
        }

        public async Task<DeleteResponse> DeleteAsync(string id)
        {

            var response = await _client.DeleteAsync<Product>(id, x => x.Index(indexName));
            return response;
        }
    }
}
