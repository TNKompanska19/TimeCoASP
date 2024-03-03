using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeCo.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
             .Property(x => x.Name)
             .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired();
        }
    }
}
