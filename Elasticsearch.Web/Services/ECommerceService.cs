using Elasticsearch.Web.Repositories;
using Elasticsearch.Web.ViewModels;

namespace Elasticsearch.Web.Services
{
	public class ECommerceService : IECommerceService
	{
		private readonly IECommerceRepository _repository;

		public ECommerceService(IECommerceRepository repository)
		{
			_repository = repository;
		}

		public async Task<(List<ECommerceViewModel> list, long totalCount, long pageLinkCount)> SearchAsync(ECommerceSearchViewModel searchModel, int page, int pageSize)
		{
			var (eCommercelist, totalCount) = await _repository.SearchAsync(searchModel, page, pageSize);

			var pageLinkCountCalculate = totalCount % pageSize;
			long pageLinkCount = 0;

			if (pageLinkCountCalculate == 0)
			{
				pageLinkCount = totalCount / pageSize;
			}
			else
			{
				pageLinkCount = (totalCount / pageSize) + 1;
			}

			var eCommerceListViewModel = eCommercelist.Select(s => new ECommerceViewModel()
			{
				Id = s.Id,
				OrderId = s.OrderId,
				Category = String.Join(",", s.Category),
				CustomerFullName = s.CustomerFullName,
				CustomerFirstName = s.CustomerFirstName,
				CustomerLastName = s.CustomerLastName,
				OrderDate = s.OrderDate.ToShortDateString(),
				Gender = s.Gender.ToLower(),
				TaxfulTotalPrice = s.TaxfulTotalPrice
			}).ToList();

			return (eCommerceListViewModel, totalCount, pageLinkCount);
		}
	}
}
