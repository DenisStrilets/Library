using BookingAppStore4.DALNew.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppStore4.DALNew
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base("LibraryContext")
        {

        }

        public ApplicationContext()
        {

        }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
