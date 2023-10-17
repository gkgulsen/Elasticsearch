using Elasticsearch.Web.ViewModels;

namespace Elasticsearch.Web.Services
{
    public interface IBlogService
    {
        Task<bool> SaveAsync(BlogCreateViewModel model);
        Task<List<BlogViewModel>> SearchAsync(string searchText);
    }
}
