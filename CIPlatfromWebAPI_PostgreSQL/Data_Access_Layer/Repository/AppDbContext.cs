using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Data_Access_Layer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<Missions> Missions { get; set; }
        public DbSet<MissionTheme> MissionThemes { get; set; }
        public DbSet<MissionSkill> MissionSkills { get; set; }

    }
}
