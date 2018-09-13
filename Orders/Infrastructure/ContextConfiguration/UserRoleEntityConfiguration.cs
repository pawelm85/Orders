using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ContextConfiguration
{
    public class UserRoleEntityConfiguration:EntityTypeConfiguration<Role>
    {
        public UserRoleEntityConfiguration()
        {
            this.ToTable("AppUserRoles");
            //this.HasKey<string>(r => r.Id);
            this.Property(p => p.Name).HasMaxLength(50);
            this.HasIndex(r => r.Name).IsUnique();
            this.HasKey(r => r.EntityId)
                .Property(r => r.EntityId)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}



