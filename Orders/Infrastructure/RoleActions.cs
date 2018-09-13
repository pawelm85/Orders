using Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class RoleActions
    {
        internal void CreateAdmin()
        {
            User admin = new User { UserName = "admin@admin.com", Email = "admin@admin.com", Password = "Pa$$word" };

            Role adminRole = new Role { Name = "Administrator" };
            adminRole.AddUser(admin);

           }

        //internal void CreateCustomerRole()
        //{
        //    IdentityResult idRoleResult;

        //    using (var context = new ApplicationDbContext())
        //    {
        //        var roleStore = new RoleStore<IdentityRole>(context);
        //        var roleManager = new RoleManager<IdentityRole>(roleStore);
        //        if (!roleManager.RoleExists("Customer"))
        //        {
        //            idRoleResult = roleManager.Create(new IdentityRole("Customer"));
        //        }
        //    }
        //}


    }
}
