using AvanceradLabb3.Models;

namespace AvanceradLabb3.Repositories
{
    public interface ILinkRepo : IRepository<Hyperlink>
    {
        public Task CreateWith(Hyperlink t, int interestId, int personId);
        public Task<ICollection<Hyperlink>> GetAllWith();

        public Task<ICollection<Hyperlink>> GetAllByPerson(int personId);
    }
}
