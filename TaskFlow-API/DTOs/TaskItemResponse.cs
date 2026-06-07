using TaskFlow_API.Models;

namespace TaskFlow_API.DTOs
{
    public class TaskItemResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public TaskItemStatus Status { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public AssignedUser? AssignedTo { get; set; }  // only populated when needed
        public DateTime CreatedAt { get; set; }
    }
}
