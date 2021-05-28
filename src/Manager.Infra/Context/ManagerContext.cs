using Manager.Domain.Entities;
using Manager.Infra.Mappiengs;
using Microsoft.EntityFrameworkCore;

namespace Maneger.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {}

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;User Id=postgres;Password=root;Database=manager_user;Pooling=true;maxPoolSize=1000;");
        }

        public virtual DbSet<User> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}