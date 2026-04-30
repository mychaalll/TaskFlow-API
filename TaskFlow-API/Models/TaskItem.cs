namespace TaskFlow_API.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Description { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.NotStarted;
        public Guid AssignedToUserId { get; set; }
        public User? AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum TaskItemStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold,
        Cancelled
    }
}
