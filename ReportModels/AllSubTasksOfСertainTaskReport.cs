using ConsoleApp1.Models;

namespace ConsoleApp1.ReportModels
{
    public class AllSubTasksOfСertainTaskReport
    {
        public List<string> TaskTitles { get; set; } = new();
        public List<DateTime> TaskDeadlines { get; set; } = new();
        public List<Status> TaskStatus { get; set; } = new();
    }
}
