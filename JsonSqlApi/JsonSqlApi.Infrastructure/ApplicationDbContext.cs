using JsonSqlApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace JsonSqlApi.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context)
            : base(context) { }

        public DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<ToDo> todos = new List<ToDo>();

            for (int i = 1; i < 100; i++)
            {
                todos.Add(new ToDo()
                {
                    Id = i,
                    Title = "My Test",
                    Body = @"{""Item"":""Kevin Stewart"",""Completed"":true}"
                });
            }

            modelBuilder.Entity<ToDo>().HasData(todos);

            base.OnModelCreating(modelBuilder);
        }
    }
}
