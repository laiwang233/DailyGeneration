using DailyGeneration.Application.Dtos;
using DailyGeneration.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DailyGeneration.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoApplication _todoApplication;

        public TodoController(TodoApplication todoApplication)
        {
            _todoApplication = todoApplication;
        }

        [HttpGet]
        public async Task<TodoDto?> GetById(Guid id) => await _todoApplication.GetByIdAsync(id);

        [HttpPost]
        public async Task<TodoDto> Add(TodoDto todoDto) => await _todoApplication.AddAsync(todoDto);

    }
}
