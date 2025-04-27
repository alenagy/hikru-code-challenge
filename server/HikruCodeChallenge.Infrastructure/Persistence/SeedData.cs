using HikruCodeChallenge.Domain.Entities;

namespace HikruCodeChallenge.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Recruiters.Any())
            {
                context.Recruiters.AddRange(new[]
                {
                    new Recruiter { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Alice Johnson" },
                    new Recruiter { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Bob Smith" }
                });
            }

            if (!context.Departments.Any())
            {
                context.Departments.AddRange(new[]
                {
                    new Department { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Engineering" },
                    new Department { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Human Resources" }
                });
            }

            context.SaveChanges();
        }
    }
}
