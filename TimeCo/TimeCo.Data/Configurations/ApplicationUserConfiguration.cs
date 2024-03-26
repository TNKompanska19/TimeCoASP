using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeCo.Data.Configurations
{
    public class ApplicationUserConfiguration
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
               .HasOne<Role>(x => x.Role)
               .WithMany(u => u.Users)
               .HasForeignKey(s => s.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.RoleId)
            .IsRequired(false);
        }
    }
}
