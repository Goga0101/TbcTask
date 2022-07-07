using Microsoft.EntityFrameworkCore;
using TbcTask.Entities;

namespace TbcTask.Models
{
    public static class GenderSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
               new Gender
               {
                   GenderId = 1,
                   GenderName = "Man"
               },
               new Gender
               {
                   GenderId = 2,
                   GenderName = "Femele"
               }
               );

        }

    }
}
