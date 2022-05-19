using JsonSqlApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace JsonSqlApi.Infrastructure
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext context;

        public ToDoRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        public Task<ToDo[]> GetAllToDoAsync()
        {
            return this.context.ToDo.ToArrayAsync();
        }
    }
}
