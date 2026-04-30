using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow_API.DTOs;
using TaskFlow_API.Models;

namespace TaskFlow_API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Name = "Design Database Schema",
                Description = "Create the initial database schema for the project.",
                Status = TaskItemStatus.InProgress,
                AssignedToUserId = Guid.Parse("7e983b86-4d5a-466b-8754-fdb2adcd3bed")
            },
            new TaskItem
            {
                Name = "Implement Authentication",
                Description = "Set up user authentication and authorization.",
                Status = TaskItemStatus.NotStarted,
                AssignedToUserId = Guid.NewGuid()
            },
            new TaskItem
            {
                Name = "Create API Endpoints",
                Description = "Develop RESTful API endpoints for task management.",
                Status = TaskItemStatus.NotStarted,
                AssignedToUserId = Guid.Parse("7e983b86-4d5a-466b-8754-fdb2adcd3bed")
            },
            new TaskItem
            {
                Name = "Write Unit Tests",
                Description = "Write unit tests for the API endpoints.",
                Status = TaskItemStatus.NotStarted,
                AssignedToUserId = Guid.NewGuid()
            },
            new TaskItem
            {
                Name = "Deploy to Production",
                Description = "Deploy the application to the production environment.",
                Status = TaskItemStatus.NotStarted,
                AssignedToUserId = Guid.NewGuid()
            }
        };

        [HttpGet]
        [EndpointSummary("Get all tasks")]
        [EndpointDescription("Returns a list of all task items.")]
        [Produces("application/json")]
        public IActionResult GetTasksList()
        {
            var tasksResponse = tasks.Select(t => new TaskItemResponse
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t.Status,
                AssignedToUserId = t.AssignedToUserId,
                AssignedTo = null,
                CreatedAt = t.CreatedAt
            });
            if (tasksResponse is null || tasksResponse.Count() == 0)
                return NotFound($"No tasks found.");
            return Ok(tasksResponse);
        }

        [HttpGet("{id:guid}")]
        [EndpointSummary("Get task by id")]
        [EndpointDescription("Returns a task.")]
        [Produces("application/json")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task is null)
                return NotFound($"Task with ID {id} not found.");

            return Ok(new TaskItemResponse
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                AssignedToUserId = task.AssignedToUserId,
                AssignedTo = null,
                CreatedAt = task.CreatedAt
            });
        }

        [HttpGet("user/{userId:guid}")]
        [EndpointSummary("Get tasks by user")]
        [EndpointDescription("Returns a task list of a user.")]
        [Produces("application/json")]
        public IActionResult GetTaskByUser(Guid userId)
        {
            var tasksResponse = tasks.Where(t => t.AssignedToUserId == userId);
            if (tasksResponse is null || tasksResponse.Count() == 0)
                return NotFound($"No tasks found for user with ID {userId}.");
            return Ok(tasksResponse);
        }
    }
}
