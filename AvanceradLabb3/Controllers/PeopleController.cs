using AvanceradLabb3.Data;
using AvanceradLabb3.Models;
using AvanceradLabb3.Models.DTO;
using AvanceradLabb3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvanceradLabb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepo _repo;
 
        public PeopleController(IPersonRepo personRepo)
        {
            _repo = personRepo;

        }

        // CREATE

        [HttpPost("{addMe}", Name = "Add Person")]
        public async Task<ActionResult> AddPerson(AddPersonReq addMe)
        {
            if(addMe == null)
            {
                return BadRequest();
            }

            var addPerson = ResponseConverter.ToPerson(addMe);

            await _repo.Create(addPerson);

            return Ok("Person was added");

        }

        // READ
        [HttpGet(Name = "Get all de people")]
        public async Task<ActionResult<ICollection<GetPersonRes>>> GetAllPeople()
        {
            var allPeople = await _repo.GetAllWithExtra();
            var result = ResponseConverter.ToPersonList(allPeople);

            return Ok(result);
        }

        [HttpGet("{id}", Name = "Get Person By Id")]
        public async Task<ActionResult<GetPersonRes>> GetPeopleById(int id)
        {
            var gotPerson = await _repo.GetById(id);
            if (gotPerson == null)
            {
                return NotFound();
            }

            return Ok(ResponseConverter.ToPersonReq(gotPerson));
        }


        // UPDATE
        [HttpPut("{id}", Name = "Update person")]
        public async Task<ActionResult> UpdatePerson(AddPersonReq updateMe, int id)
        {
            var updateThis = await _repo.GetById(id);
            if (updateThis == null) {
                return NotFound();
            }

            updateThis.FirstName = updateMe.FirstName;
            updateThis.LastName = updateMe.LastName;
            updateThis.Email = updateMe.Email;
            updateThis.Age = updateMe.Age;

            await _repo.Update(updateThis);

            return Ok($"{updateThis.FirstName} has been updated");
        }

        [HttpPut("Details", Name = "Add interest to person")]
        public async Task<ActionResult> AddInterestToPerson(int personId, int interestId)
        {
            var addToMe = await _repo.GetById(personId);
            
            if (addToMe == null) 
            { return NotFound(); }

            await _repo.AddInterestToPerson(addToMe, interestId);

            return Ok($"Interest added to {addToMe.FirstName}");
            
        }

        // DELETE
        [HttpDelete("{id}", Name = "Delete person")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var deleteMe = await _repo.GetById(id);
            if (deleteMe == null)
            {
                return NotFound();
            }
            await _repo.Delete(deleteMe);

            return Ok("Person deleted");
        }
    }
}
