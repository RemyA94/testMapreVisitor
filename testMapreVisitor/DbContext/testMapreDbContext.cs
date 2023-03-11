using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testMapreVisitor.Models;

namespace testMapreVisitor.DbContext
{
    public class testMapreDbContext : IdentityDbContext
    {
        public testMapreDbContext(DbContextOptions<testMapreDbContext> options) : base(options)
        {
        }
        public DbSet<Visitor> visitors { get; set; }
    }
}
