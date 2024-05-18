namespace TaskMaster.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<TaskCategory> TaskCategories { get; set; }
    }

}
