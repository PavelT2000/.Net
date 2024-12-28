using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOLIst;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<MyTask>> GetAllTasks()
        {


            return Ok(TasksData.GetTasks());
        }


        [HttpGet("{id}")]
        public ActionResult<MyTask> GetTaskByID(int id)
        {
            return Ok(TasksData.GetTaskById(id));
        }

        [HttpPost]
        public ActionResult<MyTask> AddTask([FromBody] CreateTaskRequest newTask)
        {
            if (newTask != null)
            {
                TasksData.AddTask(newTask.Title, newTask.Description, newTask.Date);
                return CreatedAtAction("ОК", newTask); // Возвращаем 201 с данными новой задачи

            }
            else
            {
                return BadRequest("Invalid task data.");
            }
        }
        // Метод для обновления задачи по ID
        [HttpPut("{id}")] // Маршрут: api/tasks/{id}
        public ActionResult UpdateTask(int id, [FromBody] UpdateTaskRequest updatedTask)
        {

            var task =TasksData.GetTaskById(id);
            task.SetName(updatedTask.Title);
            task.SetDescription(updatedTask.Description);
            task.SetDate(updatedTask.Date);
            return Ok(task);    

            
            
        }
        [HttpDelete("{id}")]
        public ActionResult RemoveTask(int id)
        {

            TasksData.RemoveTask(id);
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

