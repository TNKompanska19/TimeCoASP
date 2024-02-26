using TimeCo.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeCo.Data.Configurations
{
    public class vacationConfiguration : IEntityTypeConfiguration<Vacation>
    { 
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder
             .Property(x => x.Name)
             .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired();

            builder
                .Property(x => x.StartDate)
                .IsRequired();

            builder
                .Property(x => x.EndDate)
                .IsRequired();

            builder
                .HasOne<ApplicationUser>(x => x.User)
                .WithMany(u => u.Vacations)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
