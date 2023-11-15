using Application.Dtos;
using Entities;
using Mapster;
using Repository;

namespace Application.Apps
{
    public class TodoApplication
    {
        private readonly TodoRepository _todoRepository;

        public TodoApplication(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> AddAsync(TodoDto todoDto)
        {
            var res = await _todoRepository.AddAsync(todoDto.Adapt<Todo>());
            return res.Adapt<TodoDto>();
        }

        public async Task<TodoDto?> GetByIdAsync(Guid id)
        {
            var res = await _todoRepository.GetByIdAsync(id);
            return res.Adapt<TodoDto>();
        }
    }
}