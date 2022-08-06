using SnackWebSite.Models;

namespace SnackWebSite.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
