using SnackWebSite.Data;
using SnackWebSite.Models;
using SnackWebSite.Repositories.Interfaces;

namespace SnackWebSite.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}
