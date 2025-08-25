using AppMetasApi.Models;
using AppMetasApi.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AppMetasApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Goal>  Goals { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
