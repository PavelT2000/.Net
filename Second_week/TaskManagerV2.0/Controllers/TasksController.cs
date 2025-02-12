using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using TaskManagerV2._0.Data;
using TaskManagerV2._0.Models;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // Получить список задач пользователя
    [HttpGet("user")]
    [Authorize]
    public IActionResult GetTasksByUserId()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var user = _context.Users.Include(u => u.Tasks).FirstOrDefault(u => u.Id == userId);
        if (user == null)
            return NotFound("Пользователь не найден.");

        return Ok(user.Tasks);
    }

    // Добавить задачу
    [HttpPost("add")]
    [Authorize] // Требуется аутентификация
    public IActionResult AddTask([FromBody] MyTaskDTO taskRequest)
    {
        var task = new MyTask();
        task.Title = taskRequest.name;
        task.Description = taskRequest.description;
        // Получение UserId из токена
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        var user = _context.Users.Include(u => u.Tasks).FirstOrDefault(u => u.Id == userId);
        if (user == null)
            return Unauthorized("Пользователь не найден.");

        task.UserId = userId; // Привязываем задачу к текущему пользователю
        task.UserId = userId;
        task.User = user;
        _context.Tasks.Add(task);
        _context.SaveChanges();

        return Ok("Успещно добавлено");
    }
    [Authorize]
    [HttpDelete("Delete/{Id}")]
    public IActionResult RemoveTask(int Id)
    {
        var task =_context.Tasks.Find(Id);
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        if (task == null || task.UserId!=userId) return NotFound("Задача не найдена");
        
        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return Ok("Задача удалена");

    }

    public class MyTaskDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        
    }
}
