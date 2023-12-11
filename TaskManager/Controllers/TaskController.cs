using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Context;
using TaskManager.Models;
using TaskManager.Models.Forms;

namespace TaskManager.Controllers
{
    // /api/task
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<TaskClass>> GetAll()
        {
            return Ok(FakeDB.Tasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<TaskClass> GetById(int id)
        {
            TaskClass? task = FakeDB.Tasks.Where(x => x.TaskId == id).SingleOrDefault();
            return task is not null ? Ok(task) : NotFound();
        }

        [HttpPost]
        public ActionResult<TaskClass> Create(CreateTaskForm form)
        {
            TaskClass newTask = new TaskClass
            {
                TaskId = FakeDB.Tasks.Max(x => x.TaskId) + 1,
                Title = form.Title,
                Description = form.Description,
                IsCompleted = false
            };

            FakeDB.Tasks.Add(newTask);

            return Created($"https://localhost:7040/api/Task/{newTask.TaskId}", newTask);
        }

        //localhost:7040/api/Task/12/Completed

        [HttpPatch]
        [Route("{id:int}/Completed")]
        public ActionResult UpdateCompleted(int id, UpdateTaskCompletedForm form)
        {

            TaskClass? task = FakeDB.Tasks.Where(x => x.TaskId == id).SingleOrDefault();

            if (task is not null)
            {
                task.IsCompleted = form.IsCompleted;
                return NoContent();
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("id:int")]
        public ActionResult Delete(int id)
        {
            TaskClass? taskToDelete = FakeDB.Tasks.Where(x => x.TaskId == id).SingleOrDefault();

            if(taskToDelete is not null)
            {
                FakeDB.Tasks.Remove(taskToDelete);
                return NoContent();
            }

            return NotFound();

        }
    }
}
