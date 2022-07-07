using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TbcTask.Interfaces;
using TbcTask.Mapping;
using TbcTask.Models;
using TbcTask.Models.PersonModels;

namespace TbcTask.Services
{
    public class PersonService : IPersonService
    {
        private readonly TbcTaskContext _context;
        private readonly IMapper<Entities.Person, PersonModel> _personMapper;

        public PersonService(TbcTaskContext context)
        {
            _personMapper = new PersonMapper();
            _context = context;
        }

        [HttpPost]

        public CreatePersonResponse CreatePerson(PersonModel person)
        {
            var personAlreadyExists = _context.Persons.Any(p => p.Id == person.Id);

            if (personAlreadyExists)
            {
                throw new DbUpdateException($"Person with id '{person.Id}' already exist.");
            }

            var record = _context.Persons.Add(_personMapper.MapFromModelToEntity(person));

            _context.SaveChanges();

            return new CreatePersonResponse { CreatedPerson = _personMapper.MapFromEntityToModel(record.Entity) };

        }


        [HttpGet]

        public GetPersonResponse GetPerson(GetPersonRequest getPersonRequest)
        {
            var person = _context.Persons.Find(getPersonRequest.Id);

            return new GetPersonResponse { Person = _personMapper.MapFromEntityToModel(person) };
        }

        [HttpPost]

        public UpdatePersonResponse UpdatePerson(UpdatePersonRequest updatePersonRequest)
        {
            var personExist = _context.Persons.Any(x => x.Id == updatePersonRequest.UpdateToPerson.Id);

            if (!personExist)
            {
                throw new DbUpdateException($"Person with such ID doesn't exist");
            }

            var existingEntity = _context.Persons.Find(updatePersonRequest.UpdateToPerson.Id);

            existingEntity.FirstName = updatePersonRequest.UpdateToPerson.FirstName;
            existingEntity.LastName = updatePersonRequest.UpdateToPerson.LastName;
            existingEntity.PIN = updatePersonRequest.UpdateToPerson.PIN;
            existingEntity.DateTime = updatePersonRequest.UpdateToPerson.DateTime;
            existingEntity.GenderId = updatePersonRequest.UpdateToPerson.GenderId;
            existingEntity.Email = updatePersonRequest.UpdateToPerson.Email;
            existingEntity.Status = updatePersonRequest.UpdateToPerson.Status;


        _context.SaveChanges();

            return new UpdatePersonResponse { UpdatedPerson = updatePersonRequest.UpdateToPerson };

        }

        [HttpPost]

        public DeletePersonResponse DeletePerson(DeletePersonRequest deletePersonRequest)
        {
            var personToDelete = _context.Persons.Find(deletePersonRequest.Id);
            if (personToDelete == null)
            {
                throw new DbUpdateException($"Person with id '{deletePersonRequest.Id}' doesn't exist.");
            }

            _context.Persons.Remove(personToDelete);

           
            _context.SaveChanges();

            return new DeletePersonResponse();
        }


    }
}
