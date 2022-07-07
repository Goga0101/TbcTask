using TbcTask.Interfaces;
using TbcTask.Models;

namespace TbcTask.Mapping
{
    public class PersonMapper : IMapper<Entities.Person, PersonModel>
    {
        public PersonModel MapFromEntityToModel(Entities.Person source) => new PersonModel
        {

            Id = source.Id,
            FirstName = source.FirstName,
            LastName = source.LastName,
            PIN = source.PIN,
            DateTime = source.DateTime,
            GenderId = source.GenderId,
            Email = source.Email,
            Status = source.Status,
        };

        public Entities.Person MapFromModelToEntity(PersonModel source)
        {
            var entity = new Entities.Person();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(PersonModel source, Entities.Person target)
        {
            target.Id = source.Id;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.PIN = source.PIN;
            target.DateTime = source.DateTime;
            target.GenderId = source.GenderId;
            target.Email = source.Email;
            target.Status = source.Status;
        }

    }
}
 