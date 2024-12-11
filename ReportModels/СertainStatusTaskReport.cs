namespace ConsoleApp1.ReportModels
{
    public class СertainStatusTaskReport
    {
        public List<string> TaskTitles { get; set; } = new();
        public List<string> EmployeeNames { get; set; } = new();
        public List<DateTime> TaskDeadlines { get; set; } = new();
    }
}
