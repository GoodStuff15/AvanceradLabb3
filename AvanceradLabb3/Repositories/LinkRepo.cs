using AvanceradLabb3.Data;
using AvanceradLabb3.Models;
using Microsoft.EntityFrameworkCore;

namespace AvanceradLabb3.Repositories
{
    public class LinkRepo : ILinkRepo
    {
        private readonly InterestContext _ctx;

        public LinkRepo(InterestContext ctx)
        {
            _ctx = ctx;
        }
        public async Task CreateWith(Hyperlink t, int interestId, int personId)
        {
            t.Interest = await _ctx.Interests.FindAsync(interestId);
            t.Person = await _ctx.People.FindAsync(personId);
            await _ctx.Hyperlinks.AddAsync(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task Create(Hyperlink t)
        {
            await _ctx.Hyperlinks.AddAsync(t);
            await _ctx.SaveChangesAsync();
        }

        public Task Delete(Hyperlink t)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Hyperlink>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Hyperlink>> GetAllWith()
        {
            return await _ctx.Hyperlinks
                         .Include(p => p.Person)
                         .Include(i => i.Interest)
                         .ToListAsync();

            
        }
        public Task<Hyperlink> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Hyperlink>> GetAllByPerson(int personId)
        {
            //var person = await _ctx.People.FindAsync(personId);
            var query = await _ctx.Hyperlinks
                        .Where(p => p.Person.Id == personId)
                        .ToListAsync();

            return query;
        }

        public Task Update(Hyperlink t)
        {
            throw new NotImplementedException();
        }
    }
}
