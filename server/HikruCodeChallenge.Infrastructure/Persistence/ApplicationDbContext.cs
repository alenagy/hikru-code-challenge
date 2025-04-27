using HikruCodeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HikruCodeChallenge.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
