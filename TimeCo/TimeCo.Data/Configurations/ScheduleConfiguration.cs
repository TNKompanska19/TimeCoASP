using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeCo.Common.Contracts;

namespace TimeCo.Data.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder
             .Property(x => x.Shift)
             .IsRequired();
            builder
                .Property(x => x.StartDate)
                .IsRequired();

            builder
                .Property(x => x.EndDate)
                .IsRequired();

            builder
                .HasOne<ApplicationUser>(x => x.User)
                .WithMany(u => u.Schedules)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
