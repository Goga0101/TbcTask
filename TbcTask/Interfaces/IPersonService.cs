using TbcTask.Entities;
using TbcTask.Models;
using TbcTask.Models.PersonModels;

namespace TbcTask.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> Search(string name);
        GetPersonResponse GetPerson(GetPersonRequest request);

        CreatePersonResponse CreatePerson(PersonModel request);

        UpdatePersonResponse UpdatePerson(UpdatePersonRequest request);

        DeletePersonResponse DeletePerson(DeletePersonRequest request);
    }
}
