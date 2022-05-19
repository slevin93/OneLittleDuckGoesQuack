using JsonSqlApi.Service.ToDoItems.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JsonSqlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ISender sender;

        public TodosController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get()
        {
            return Ok(await sender.Send(new ToDoItemsQueryRequest()));
        }
    }
}