using Elasticsearch.Web.Models;
using Elasticsearch.Web.ViewModels;

namespace Elasticsearch.Web.Repositories
{
	public interface IECommerceRepository
	{
		Task<(List<ECommerce> list, long count)> SearchAsync(ECommerceSearchViewModel searchViewModel, int page, int pageSize);
	}
}
