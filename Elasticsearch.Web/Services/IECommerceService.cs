using Elasticsearch.Web.ViewModels;

namespace Elasticsearch.Web.Services
{
	public interface IECommerceService
	{
		Task<(List<ECommerceViewModel> list, long totalCount, long pageLinkCount)> SearchAsync(ECommerceSearchViewModel searchModel, int page, int pageSize);
	}
}
