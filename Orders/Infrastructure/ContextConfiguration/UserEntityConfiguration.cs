using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ContextConfiguration
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.ToTable("AppUsers");
            this.Property(p => p.UserName).HasMaxLength(50);
            this.HasIndex(i => i.UserName).IsUnique();
            this.HasKey(u => u.EntityId)
                .Property(u=>u.EntityId)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
