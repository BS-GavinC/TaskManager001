using TaskManager.Models;

namespace TaskManager.Context
{
    public static class FakeDB
    {
        public static List<TaskClass> Tasks { get; set; } = new List<TaskClass>()
        {
            new TaskClass
            {
                TaskId = 1,
                Title = "Test",
                Description = "TestDesc",
                IsCompleted = false
            },
            new TaskClass
            {
                TaskId = 2,
                Title = "TaskComplete",
                Description = "TaskCompleteDesc",
                IsCompleted = true
            },
            new TaskClass
            {
                TaskId = 3,
                Title = "TaskIncomplete",
                Description = "TaskIncompleteDesc",
                IsCompleted = false
            },
        };
    }
}
