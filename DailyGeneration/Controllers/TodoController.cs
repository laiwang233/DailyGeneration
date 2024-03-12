using Application.Apps;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace DailyGeneration.Controllers
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
