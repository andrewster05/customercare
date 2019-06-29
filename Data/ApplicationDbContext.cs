using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CustomerCare.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Data
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }

    public class ApplicationDbContext 
        : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbQuery<CustomersSearchResult> CustomersSearchResult { get; set; }
    }
}
