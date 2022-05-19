using JsonSqlApi.Domain;

namespace JsonSqlApi.Infrastructure
{
    public interface IToDoRepository
    {
        Task<ToDo[]> GetAllToDoAsync();
    }
}
