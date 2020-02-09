using System.Threading.Tasks;
using What.Beer.Common.Domain;

namespace What.Beer.Data.Repositories
{
    public interface IBeerRepository
    {
        Task<Common.Domain.Beer> FindById(string id);
        Task SaveOrUpdate(Common.Domain.Beer toSave);
    }
}
