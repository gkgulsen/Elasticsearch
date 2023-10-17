using Elasticsearch.Web.Models;

namespace Elasticsearch.Web.Repositories
{
    public interface IBlogRepository
    {
        Task<Blog?> SaveAsync(Blog newBlog);
        Task<List<Blog>> SearchAsync(string searchText);
    }
}
