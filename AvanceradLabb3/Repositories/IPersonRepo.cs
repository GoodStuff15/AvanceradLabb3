using AvanceradLabb3.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvanceradLabb3.Repositories
{
    public interface IPersonRepo : IRepository<Person>
    {
        public Task<ICollection<Person>> GetAllWithExtra();

        public Task AddInterestToPerson(Person p, int interestId);

    }
}
