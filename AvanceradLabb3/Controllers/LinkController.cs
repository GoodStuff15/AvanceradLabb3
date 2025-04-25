using AvanceradLabb3.Models;
using AvanceradLabb3.Models.DTO;
using AvanceradLabb3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AvanceradLabb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkRepo _linkRepo;


        public LinkController(ILinkRepo lRepo)
        {
            _linkRepo = lRepo;

        }
        
        // CREATE
        [HttpPost("Details", Name ="Create a link (organized by person and interes t")]
        public async Task<ActionResult> AddLink(int personId, int interestId, LinkDTO newLink)
        {
            if (newLink == null) { return BadRequest(); }

            var addThis = new Hyperlink
            {
                Title = newLink.Title,
                Url = newLink.Url,
            };

            await _linkRepo.CreateWith(addThis, interestId, personId);

            return Ok("Added");

        }
        // READ

        [HttpGet(Name = "Get all links, people and interest included")]
        public async Task<ActionResult<ICollection<LinkDTO>>> GetAllWith()
        {
            var response =  await _linkRepo.GetAllWith();
            var result = ResponseConverter.ToLinkList(response);

            return Ok(result);
            
        }

        [HttpGet("Details", Name = "Get all links of a person")]
        public async Task<ActionResult<ICollection<Hyperlink>>> GetAllByPerson(int personId)
        {
            var result = await _linkRepo.GetAllByPerson(personId);

            if (result == null)
            {
                return NotFound("Not Found");
            }
            var response = ResponseConverter.ToLinkList(result);

            return Ok(response);
        }


        //[HttpGet("{id}", Name="Get all Links of specific person")]
        //public async Task<ActionResult<ICollection<LinkDTO>>> GetAllPersonLinks(int id)
        //{
        //    var person = await _personRepo.GetById(id);

        //    var personLinks = from _linkRepo.GetAll()
        //}
    }
}
