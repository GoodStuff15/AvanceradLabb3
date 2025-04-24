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

        //[HttpGet("{id}", Name = "Get Person By Id")]
        //public async Task<ActionResult<GetPersonRes>> GetPeopleById(int id)
        //{
        //    var gotPerson = await _repo.GetById(id);
        //    if (gotPerson == null)
        //    {
        //        return NotFound();
        //    }
        //    var result = new GetPersonRes
        //    {
        //        FirstName = gotPerson.FirstName,
        //        LastName = gotPerson.LastName,
        //        Email = gotPerson.Email,
        //        Age = gotPerson.Age,
        //    };
        //    return Ok(result);
        //}

        //[HttpGet("{id}", Name = "Get Person with Interests")]
        //public async Task<ActionResult<GetPersonRes>> GetWithInterests(int id)
        //{
        //    var getMe = await _repo.GetById(id);
        //    if (getMe == null) { return NotFound(); }

        //    var result = new GetPersonRes
        //    {
        //        FirstName = getMe.FirstName,
        //        LastName = getMe.LastName,
        //        Email = getMe.Email,
        //        Age = getMe.Age,
        //        Interests = getMe.Interests
        //    };
        //    return Ok(result);
        //}

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

            return Ok("Person has been updated");
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
