
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace Elasticsearch.API.Extentions
{
    public static class Elasticsearch
    {
        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            var userName = configuration.GetSection("Elastic")["Username"];
            var password = configuration.GetSection("Elastic")["Password"];

            var settings = new ElasticsearchClientSettings(new Uri(configuration.GetSection("Elastic")["Url"]!))
                .Authentication(new BasicAuthentication(userName!, password!));


            var client=new ElasticsearchClient(settings);

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
    }
}
