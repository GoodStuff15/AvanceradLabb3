using AvanceradLabb3.Data;
using AvanceradLabb3.Models;
using Microsoft.EntityFrameworkCore;

namespace AvanceradLabb3.Repositories
{
    public class PersonRepo : IPersonRepo
    {
        private readonly InterestContext _ctx;

        public PersonRepo(InterestContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Person t)
        {
            await _ctx.People.AddAsync(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(Person t)
        {
            _ctx.People.Remove(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Person>> GetAll()
        {
            return await _ctx.People.ToListAsync();
        }

        public async Task<ICollection<Person>> GetAllWithExtra()
        {
            return await _ctx.People.Include(i => i.Interests).ToListAsync();
        }

        //public async Task<Person?> GetByIdExtraAll(int id)
        //{
        //    //return await _ctx.People.Include(i => i.Interests).FindAsync(id);
        //}

        public async Task<Person?> GetById(int id)
        {
          
            return await _ctx.People.FindAsync(id);
        }

        public async Task Update(Person t)
        {
            _ctx.People.Update(t);
            await _ctx.SaveChangesAsync();
        
            
        }
    }
}
