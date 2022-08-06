using Microsoft.EntityFrameworkCore;
using SnackWebSite.Data;
using SnackWebSite.Models;
using SnackWebSite.Repositories.Interfaces;

namespace SnackWebSite.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;

        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Snack> Snacks => _context.Snacks.Include(x => x.Category);

        public IEnumerable<Snack> MySnackPrefer => _context.Snacks.Where(x => x.IsSnackPrefer).Include(x => x.Category);

        public Snack GetSnackById(int id) => _context.Snacks.FirstOrDefault(x => x.SnackId == id);
    }
}
