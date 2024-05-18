namespace TaskMaster.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation properties
        public ICollection<TaskCategory> TaskCategories { get; set; }
    }

}
