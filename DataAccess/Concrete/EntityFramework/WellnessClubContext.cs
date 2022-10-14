using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class WellnessClubContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=YCA;Database=BilgiWellnessClub;Trusted_Connection=true");
        }

        public DbSet<Collaboration> Collaborations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Height> Heights { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<UserHeight> UserHeights { get; set; }
        public DbSet<UserWeight> UserWeights { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
