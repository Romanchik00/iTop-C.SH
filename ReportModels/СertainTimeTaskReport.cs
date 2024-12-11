using ConsoleApp1.Models;

namespace ConsoleApp1.ReportModels
{
    public class СertainTimeTaskReport
    {
        public List<string> TaskTitles { get; set; } = new();
        public List<int> SubTaskCounts { get; set; } = new();
        public List<Status> TaskStatus { get; set; } = new();
    }
}
