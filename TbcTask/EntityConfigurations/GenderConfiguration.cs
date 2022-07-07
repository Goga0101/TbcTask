using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TbcTask.Entities;

namespace TbcTask.EntityConfigurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {

        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.GenderId);
        }

    }
}
