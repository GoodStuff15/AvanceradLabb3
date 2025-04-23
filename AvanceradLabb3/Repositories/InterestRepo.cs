using AvanceradLabb3.Data;
using AvanceradLabb3.Models;
using Microsoft.EntityFrameworkCore;

namespace AvanceradLabb3.Repositories
{
    public class InterestRepo : IInterestRepo
    {
        private readonly InterestContext _ctx;
        public InterestRepo(InterestContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Interest t)
        {
            await _ctx.Interests.AddAsync(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(Interest t)
        {
            _ctx.Interests.Remove(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Interest>> GetAll()
        {
            return await _ctx.Interests.ToListAsync();
        }

        public async Task<Interest?> GetById(int id)
        {
            return await _ctx.Interests.FindAsync(id);
        }

        public async Task Update(Interest t)
        {
            _ctx.Interests.Update(t);
            await _ctx.SaveChangesAsync();
        }
    }
}
