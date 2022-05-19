using AutoMapper;
using JsonSqlApi.Domain;
using JsonSqlApi.Service.ToDoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonSqlApi.Service.Mappers
{
    public class ToDoMapper : Profile
    {
        public ToDoMapper()
        {
            var mapper = CreateProjection<ToDo, ToDoItemsDto>();
            mapper.ForMember(x => x.ToDoItemsLists, y => y.MapFrom(u => JsonSerializer.Deserialize<ToDoItemsList>(u.Body, new JsonSerializerOptions())));
        }
    }
}
