using ConsoleApp1.Models;
using ConsoleApp1.ReportModels;

namespace ConsoleApp1
{
    public class ReportMaker
    {
        private List<Employee> employees;
        private List<myTask> tasks;
        public ReportMaker(List<Employee> employee, List<myTask> task)
        {
            employees = employee;
            tasks = task;
        }
        public СertainEmployeeReport СertainEmployee(int EmployeeId)
        {
            СertainEmployeeReport result = new();

            var tasksById = tasks.FindAll(x => x.Assignee.Id == EmployeeId);

            foreach (var item in tasksById)
            {
                result.TaskTitles.Add(item.Title);
                result.TaskDeadlines.Add(item.Deadline);
                result.TaskRisks.Add(item.risk);
                result.TaskStatus.Add(item.status);
            }
            return result;
        }
        public СertainTimeTaskReport CertainTimeTask(DateTime date)
        {
            СertainTimeTaskReport result = new();
            var tasksByDate = tasks.FindAll(x => date.CompareTo(x.CreationDate) <= 0);
            foreach (var item in tasksByDate)
            {
                result.TaskTitles.Add(item.Title);
                result.SubTaskCounts.Add(item.SubTasks.Count);
                result.TaskStatus.Add(item.status);
            }
            return result;
        }
        public СertainStatusTaskReport CertainStatusTask(Status status)
        {
            var result = new СertainStatusTaskReport();
            var tasksByStatus = tasks.FindAll(x => x.status == status);
            foreach (var item in tasksByStatus)
            {
                result.TaskTitles.Add(item.Title);
                result.EmployeeNames.Add(item.Assignee.Name);
                result.TaskDeadlines.Add(item.Deadline);
            }
            return result;
        }
        public СertainRiskTaskReport CertainRiskTask(Risks risk)
        {
            var result = new СertainRiskTaskReport();
            var tasksByRisk = tasks.FindAll(x => x.risk == risk);
            foreach (var item in tasksByRisk)
            {
                result.TaskTitles.Add(item.Title);
                result.SubTaskCounts.Add(item.SubTasks.Count);
            }
            return result;
        }
        public AllSubTasksOfСertainTaskReport AllSubTasksOfСertainTask(myTask task)
        {
            var result = new AllSubTasksOfСertainTaskReport();
            if (task.SubTasks.Count > 0)
            {
                List<myTask> allSubTasksByTask = new();
                task.SubTasks.ForEach(x =>
                {
                    allSubTasksByTask.Add(tasks.Find(y => y.Id == x));
                });

                allSubTasksByTask.ForEach(x =>
                {
                    result.TaskTitles.Add(x.Title);
                    result.TaskDeadlines.Add(x.Deadline);
                    result.TaskStatus.Add(x.status);
                });
            }
            return result;
        }
    }
}
