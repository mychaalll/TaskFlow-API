namespace TaskFlow_API.DTOs
{
    public class AssignedUser
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
