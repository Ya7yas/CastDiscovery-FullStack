using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScenePro.Models;
using ScenePro.Models.ViewModel;

namespace ScenePro.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }


    }

  
}
