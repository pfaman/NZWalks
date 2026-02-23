using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "648023a4-4382-4ba4-808e-a77cf40f1166";
            var writeRoleId = "f6084cad-4d43-4e75-98e2-1866c594a130";


            var roles = new List<IdentityRole>
            {
              new IdentityRole
              {
                  Id = readerRoleId,
                  ConcurrencyStamp = readerRoleId,
                  Name = "Reader",
                  NormalizedName = "Reader".ToUpper()
              },
              new IdentityRole
              {
                  Id = writeRoleId,
                  ConcurrencyStamp = writeRoleId,
                  Name = "Writer",
                  NormalizedName = "Writer".ToUpper()
              }

            };


            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}