using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetAllTasks()
        {


            return await _context.MyTasks.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MyTask>> GetTaskByID(int id)
        {
            return await _context.MyTasks.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<MyTask>> AddTask([FromBody] MyTask newTask)
        {
            if (newTask != null)
            {
                
                await _context.MyTasks.AddAsync(newTask);
                _context.SaveChangesAsync();
                return CreatedAtAction("ОК", newTask); // Возвращаем 201 с данными новой задачи

            }
            else
            {
                return BadRequest("Invalid task data.");
            }
            
        }
        // Метод для обновления задачи по ID
        [HttpPut("{id}")] // Маршрут: api/tasks/{id}
        public async Task<ActionResult> UpdateTask(int id, [FromBody] MyTask updatedTask)
        {

            if (id != updatedTask.Id)
            {
                return BadRequest("ID задачи в URL не совпадает с ID задачи в теле запроса.");
            }

            // Ищем задачу в базе данных
            var existingTask = await _context.MyTasks.FindAsync(id);
            if (existingTask == null)
            {
                return NotFound($"Задача с ID {id} не найдена.");
            }

            // Обновляем свойства задачи
            existingTask.Name = updatedTask.Name;
            existingTask.Description = updatedTask.Description;

            // Помечаем задачу как изменённую
            _context.Entry(existingTask).State = EntityState.Modified;

            // Сохраняем изменения в базе данных
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Произошла ошибка при обновлении задачи.");
            }

            // Возвращаем успешный результат
            return NoContent();



        }
        [HttpDelete("{id}")]
        public ActionResult RemoveTask(int id)
        {

            _context.MyTasks.Remove(_context.MyTasks.Find(id));
            _context.SaveChangesAsync();
            return NoContent();
        }

        public class CreateTaskRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
        }
        public class UpdateTaskRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public bool IsCompleted { get; set; }
        }
    }
}

