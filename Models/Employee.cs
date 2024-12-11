namespace ConsoleApp1.Models
{
    public enum Position { Frontender, Backender, Analyst, Team_leader, Accountant, Scrum_master, Administrator };
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? SupervisorId { get; set; }
    }
}
