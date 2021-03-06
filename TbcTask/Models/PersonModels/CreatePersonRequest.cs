using System.ComponentModel.DataAnnotations;
using TbcTask.Entities;
using TbcTask.Enums;

namespace TbcTask.Models
{
    public class CreatePersonRequest
    {
        public Guid Id { get; set; }

        [MinLength(2)]

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(11)]

        public string PIN { get; set; }

        [StringLength(4)]

        public string? DateTime { get; set; }

        public int GenderId { get; set; }

        public string Email { get; set; }

        public Status Status { get; set; }
    }
}
