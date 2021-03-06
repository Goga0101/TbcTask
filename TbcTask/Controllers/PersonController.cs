using Microsoft.AspNetCore.Mvc;
using TbcTask.Entities;
using TbcTask.Interfaces;
using TbcTask.Models;
using TbcTask.Models.PersonModels;

namespace TbcTask.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }





        [HttpPost("createPerson")]
        public CreatePersonResponse CreatePerson(PersonModel request) => _personService.CreatePerson(request);

        [HttpGet("getPerson")]
        public GetPersonResponse GetPerson(GetPersonRequest request) => _personService.GetPerson(request);


        [HttpPost("updatePerson")]
        public UpdatePersonResponse UpdatePerson(UpdatePersonRequest request) => _personService.UpdatePerson(request);


        [HttpPost("deletePerson")]
        public DeletePersonResponse Delete(DeletePersonRequest request) => _personService.DeletePerson(request);

        [HttpGet("Search")]


        public async Task<ActionResult<IEnumerable<Person>>> Search(string name)
        {
        try{
                var result = await _personService.Search(name);

                    if (result.Any())
                    {

                        return Ok(result);
                    }
                    return NotFound();

                }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                    ,"Error in Retrieving Data from Database ");
            }

        }
      

    }
}
