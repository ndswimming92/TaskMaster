namespace TaskMaster.Models
{
    public class TaskCategory
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties
        public Task Task { get; set; }
        public Category Category { get; set; }
    }

}
