using Microsoft.EntityFrameworkCore;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Infrastructure.Data
{
    public class OmoqoCodeChallengeDBContext : DbContext
    {
        public OmoqoCodeChallengeDBContext(DbContextOptions<OmoqoCodeChallengeDBContext> options) : base(options)
        {
        }

        public DbSet<Ship> Ships { get; set; }
    }
}
