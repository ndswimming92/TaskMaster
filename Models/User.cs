namespace TaskMaster.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int Password { get; set; }

        // Navigation properties
        public ICollection<Task> Tasks { get; set; }
    }

}
