using AvanceradLabb3.Data;
using AvanceradLabb3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvanceradLabb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly InterestContext _context;

        public PeopleController(InterestContext context)
        {
            _context = context;
        }

        // CREATE

        [HttpPost("{newPerson}", Name = "Add Person")]
        public async Task AddPerson()
        {

        }

        // READ
        [HttpGet("Get all de people")]
        public async Task<ActionResult<ICollection<Person>>> GetAllPeople()
        {
            return null;
        }

        // UPDATE
        [HttpPut("{id}", Name = "Update person")]
        public async Task<ActionResult> UpdatePerson(int id)
        {

            return null;
        }


        // DELETE
        [HttpDelete("{id}", Name = "Delete person")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            return null;
        }
    }
}
