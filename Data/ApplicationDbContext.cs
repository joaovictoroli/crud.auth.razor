using auth.studies.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace auth.studies.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<ToDo> ToDos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}