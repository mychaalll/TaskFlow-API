using TaskFlow_API.Models;

namespace TaskFlow_API.DTOs
{
    public class UpdateTaskRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }
}
