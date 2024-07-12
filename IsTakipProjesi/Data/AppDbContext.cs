using IsTakipProjesi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IsTakipProjesi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskMember> TaskMembers { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
    }
}
