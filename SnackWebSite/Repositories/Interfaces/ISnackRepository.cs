using SnackWebSite.Models;

namespace SnackWebSite.Repositories.Interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> MySnackPrefer { get; }
        Snack GetSnackById(int id);
    }
}
