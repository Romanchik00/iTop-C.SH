using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public static class DataBasesManager
    {
        public static void CreateTask( this List<myTask> myTasks, myTask task) 
        {
            myTasks.Add(task);
        }
        public static void AssignPerformer( this myTask task , Employee assignee) 
        {
            task.Assignee = assignee;
        }
        public static void EditStatus( this myTask task, Status status) 
        {
            task.status = status;
        }
        public static void EditRisk( this myTask task, Risks risk) 
        {
            task.risk = risk;
        }
        public static void AddNewSubTask( this myTask task, myTask subtask) 
        {
            task.SubTasks.Add(subtask.Id);
        }

        public static void EditPassword( this Employee employee, string newPass) 
        {
            employee.Password = newPass;
        }
        public static void CreateEmployee(this List<Employee> employees, Employee employee)
        {
            employees.Add(employee);
        }
        public static void AssignSupervisor(this Employee employee, Employee supervisor)
        {
            employee.SupervisorId = supervisor.Id;
        }
    }
}
