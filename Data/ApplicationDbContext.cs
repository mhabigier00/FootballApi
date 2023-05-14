using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FootballApi.Models;
using FootballApi.DataBase.Models;

namespace FootballApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FavouriteMatch> FavouriteMatches { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }

}