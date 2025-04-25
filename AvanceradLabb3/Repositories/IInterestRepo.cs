using AvanceradLabb3.Models;
using AvanceradLabb3.Models.DTO;

namespace AvanceradLabb3.Repositories
{
    public interface IInterestRepo : IRepository<Interest>
    {
        public Task<ICollection<Interest>> GetInterestsByPerson(int personId);
    }
}
