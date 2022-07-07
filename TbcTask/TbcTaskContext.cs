using Microsoft.EntityFrameworkCore;
using TbcTask.Entities;
using TbcTask.EntityConfigurations;
using TbcTask.Models;

namespace TbcTask
{
    public class TbcTaskContext : DbContext
    {
        public DbSet <Person> Persons { get; set; }  

        public DbSet <Gender> Genders { get; set; }



        public TbcTaskContext()
        {

        }

        public TbcTaskContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.Seed();

        }



    }
}
