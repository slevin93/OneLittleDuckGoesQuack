using AutoMapper;
using AutoMapper.QueryableExtensions;
using JsonSqlApi.Domain;
using JsonSqlApi.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSqlApi.Service.ToDoItems.Queries
{
    public class ToDoItemsQueryRequest : IRequest<ToDoItemsDto[]>
    {
        public class ToDoItemsQueryHandler : IRequestHandler<ToDoItemsQueryRequest, ToDoItemsDto[]>
        {
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;

            public ToDoItemsQueryHandler(ApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;

                // Naughty, dont do
                this.context.Database.EnsureCreated();
            }

            public async Task<ToDoItemsDto[]> Handle(ToDoItemsQueryRequest request, CancellationToken cancellationToken)
            {
                return await this.context.ToDo.ProjectTo<ToDoItemsDto>(this.mapper.ConfigurationProvider).ToArrayAsync();
            }
        }
    }
}
