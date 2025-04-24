using AvanceradLabb3.Models;
using AvanceradLabb3.Models.DTO;
using AvanceradLabb3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvanceradLabb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IInterestRepo _repo;

        public InterestController(IInterestRepo repo)
        {
            _repo = repo;
        }


        // CREATE

        [HttpPost(Name = "Add interest to database")]
        public async Task<ActionResult> AddInterest(AddInterestReq newInterest)
        {
            if (newInterest == null)
            {
                return BadRequest();
            }

            var addInterest = new Interest
            {
                Title = newInterest.Title,
                Description = newInterest.Description
            };

            await _repo.Create(addInterest);

            return Ok($"Interest {addInterest.Title} was added");
        }

        // READ

        [HttpGet(Name = "Get all interests")]
        public async Task<ActionResult<ICollection<GetInterestRes>>> GetAll()
        {
            await _repo.GetAll();
        }

        [HttpGet("{id}", Name = "Get Interest By Id")]
        public async Task<ActionResult<GetInterestRes>> GetById(int id)
        {
            var getMe = await _repo.GetById(id);

            if (getMe == null) { return NotFound(); }

            var returnThis = new GetInterestRes
            {
                Title = getMe.Title,
                Description = getMe.Description
            };

            return Ok(returnThis);
        }


        // UPDATE

        [HttpPut("{id}", Name = "Update an interest")]
        public async Task<ActionResult> UpdateInterest(AddInterestReq updatedInterest, int id)
        {
            var updateThis = await _repo.GetById(id);
            if (updateThis == null)
            {
                return NotFound();
            }

            updateThis.Title = updatedInterest.Title;
            updateThis.Description = updatedInterest.Description;
            
            await _repo.Update(updateThis);
            return Ok($"{updateThis.Title} updated");
        }

        // DELETE

        [HttpDelete("{id}", Name = "Delete an interest")]
        public async Task<ActionResult> DeleteInterest(int id)
        {
            var deleteThis = await _repo.GetById(id);
            if (deleteThis == null)
            {
                return NotFound();
            }
            await _repo.Delete(deleteThis);

            return Ok("Interest deleted");
        }
    }
}
