
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Elasticsearch.Web.Models;

namespace Elasticsearch.WEB.Extentions
{
    public static class Elasticsearch
    {
        private const string indexName = "blog";
        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            var userName = configuration.GetSection("Elastic")["Username"];
            var password = configuration.GetSection("Elastic")["Password"];

            var settings = new ElasticsearchClientSettings(new Uri(configuration.GetSection("Elastic")["Url"]!))
                .Authentication(new BasicAuthentication(userName!, password!));


            var client = new ElasticsearchClient(settings);

            AddDefaultMappings(client);

            services.AddSingleton(client);

            #region NEST PACKAGES
            //var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));
            //var settings = new ConnectionSettings(pool);
            //settings.BasicAuthentication(username: configuration.GetSection("Elastic")["Username"], 
            //                             password: configuration.GetSection("Elastic")["Password"]);            
            //var client = new ElasticClient(settings);
            //services.AddSingleton(client);
            #endregion

        }
        private static void AddDefaultMappings(ElasticsearchClient client)
        {

            var indexExistsResponse = client.Indices.Exists(indexName);

            if (!indexExistsResponse.Exists)
            {
                var createIndexResponse = client.Indices
                    .Create<Blog>(indexName, c => c
                        .Mappings(map => map
                            .Properties(props => props
                                .Text(t => t.Title, f => f.Fields(x => x.Keyword(k => k.Title)))
                                .Text(t => t.Content)
                                .Keyword(k => k.UserId)
                                .Keyword(k => k.Tags)
                                .Date(d => d.Created))));
            }
        }
    }
}
