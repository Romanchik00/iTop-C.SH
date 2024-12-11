using System.Text.Json.Serialization;
namespace ConsoleApp1.Models
{
    public enum Status { Planned, Development, Review, Closed };
    public enum Risks { Gray, Green, Yellow, Red };
    public class myTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Assignee { get; set; }
        [JsonPropertyName("Status")]
        public Status status { get; set; }
        [JsonPropertyName("Risks")]
        public Risks risk { get; set; }
        public List<int> SubTasks { get; set; } = new List<int>();
    }
}
