using ConsoleApp1.Models;

namespace ConsoleApp1.ReportModels
{
    public class СertainEmployeeReport
    {
        public List<string> TaskTitles { get; set; } = new();
        public List<DateTime> TaskDeadlines { get; set; } = new();
        public List<Risks> TaskRisks { get; set; } = new();
        public List<Status> TaskStatus { get; set; } = new();
    }
}
