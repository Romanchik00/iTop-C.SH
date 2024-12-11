// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using ConsoleApp1;
using ConsoleApp1.ReportModels;
using ConsoleApp1.Models;
using System.Text;

//--***---***----------------------------------------------------------------------***---***--
//Практика № 1
Console.Title = "База задач и сотрудников";

Console.WriteLine("##----------------------------------------------------##");
var program = new myProgram();
program.Entrance();
Console.WriteLine("##----------------------------------------------------##");

public class myProgram
{
    private List<Employee> Employees = JsonReader.EmployeeListRead("People.txt");
    private List<myTask> Tasks = JsonReader.TaskListRead("Tasks.txt");
    private AuthManager authmanager = new();
    public void Entrance()
    {
        for (int i = 0; i < 3 && CurrentConfiguration.CurrentUser == null; i++)
        {
            authmanager.Auth();
        }
        if (CurrentConfiguration.CurrentUser != null)
        {
            Console.WriteLine($"Добро пожаловать {CurrentConfiguration.CurrentUser.Name}");
            Thread.Sleep(1000);
            Console.Clear();
            StartWork();
            CreateTask(new myTask
            {
                Id = 46,
                Title = "Супер задача",
                CreationDate = new DateTime(2024, 12, 9),
                Deadline = new DateTime(2024, 12, 22)
            });
            CreateEmployee(new Employee 
            {
                Id=17,Name="Bob",Position=Position.Frontender,Login="abuzer666",
                Password="lolicon"
            });
            AssignPerformer(Tasks.Last() ,Employees.Last());
            EditStatus(Tasks.Last() ,0);
            EditRisk(Tasks.Last() ,0);
            AddNewSubTask(Tasks.Last() ,Tasks[Tasks.IndexOf(Tasks.Last()) - 1]);
            EditPassword(Employees.Find(x => x.Id == CurrentConfiguration.CurrentUser.Id), "qwerty");
            AssignSupervisor(Employees.Last(), CurrentConfiguration.CurrentUser);
            UpdateTaskBase();
            
            Console.WriteLine();
            Console.WriteLine($"\tMy Task:\n" +
                $"Id:{Tasks.Last().Id}|Title:{Tasks.Last().Title}|CreateTime:{Tasks.Last().CreationDate}\n" +
                $"\tAssignee:\n Id:{Tasks.Last().Assignee.Id}|Name:{Tasks.Last().Assignee.Name}" +
                $"|Password:{Tasks.Last().Assignee.Password}\n" +
                $"ListOfSubTasks:{Tasks.Last().SubTasks.First()}");

            JsonDBWriter.WriteJsonFile(Tasks);
            JsonDBWriter.WriteJsonFile(Employees);
        }
        else
        {
            Console.WriteLine("*-Попытки кончились. Попытайся в другой раз-*");
            Thread.Sleep(500);
        }
    }
    private void StartWork()
    {

    }
    public void CreateTask(myTask task)
    {
        if (CurrentConfiguration.CurrentUser.Position != Position.Accountant)
        {
            Tasks.CreateTask(task);
        }
        else
        {
            Console.WriteLine("--Ошибка доступа--");
            throw new Exception("--Ошибка доступа--");
        }
    }
    public void AssignPerformer(myTask task, Employee assignee)
    {
        if (CurrentConfiguration.CurrentUser.Position != Position.Accountant &&
            CurrentConfiguration.CurrentUser.Position != Position.Administrator)
        {
            if (assignee == CurrentConfiguration.CurrentUser ||
              (Employees.FindAll(x => x.SupervisorId == CurrentConfiguration.CurrentUser.Id).Contains(assignee)))
            {
                task.Assignee = assignee;
            }
        }
        else if (CurrentConfiguration.CurrentUser.Position == Position.Administrator)
        {
            task.Assignee = assignee;
        }
        else
        {
            Console.WriteLine("--Ошибка доступа--");
            throw new Exception("--Ошибка доступа--");
        }

    }
    public void EditStatus(myTask task, Status status)
    {
        if (task.SubTasks.All(x =>
        {
            if (Tasks.Find(y => y.Id == x).status == Status.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }))
        {
            task.EditStatus(status);
        }
        else
        {
            Console.WriteLine("--Закрыты не все задачи--");
            throw new Exception("--Закрыты не все задачи--");
        }
    }
    public void EditRisk( myTask task, Risks risk)
    {
        task.EditRisk(risk);
    }
    public void AddNewSubTask( myTask task, myTask subtask)
    {
        task.AddNewSubTask(subtask); 
    }

    public void EditPassword(Employee employee, string newPass)
    {
        if (CurrentConfiguration.CurrentUser.Position != Position.Administrator &&
            CurrentConfiguration.CurrentUser.Position != Position.Accountant)
        {
            if (employee.SupervisorId == CurrentConfiguration.CurrentUser.Id)
            {
                employee.EditPassword(newPass);
            }
            else
            {
                Console.WriteLine("--Ошибка доступа--");
                throw new Exception("--Ошибка доступа--");
            }
        }
        else if (CurrentConfiguration.CurrentUser.Position == Position.Administrator)
        {
            employee.EditPassword(newPass);
        }
        else
        {
            Console.WriteLine("--Ошибка доступа--");
            throw new Exception("--Ошибка доступа--");
        }
    }
    public void CreateEmployee(Employee employee)
    {
        if (CurrentConfiguration.CurrentUser.Position == Position.Administrator)
        {
            Employees.CreateEmployee(employee);
        }
        else
        {
            Console.WriteLine("--Ошибка доступа--");
            throw new Exception("--Ошибка доступа--");
        }
    }
    public void AssignSupervisor(Employee employee, Employee supervisor)
    {
        if(CurrentConfiguration.CurrentUser.Position == Position.Administrator)
        {
            employee.AssignSupervisor(supervisor);
        } 
        else
        {
            Console.WriteLine("--Ошибка доступа--");
            throw new Exception("--Ошибка доступа--");
        }
    }
    public void UpdateTaskBase()
    {
        Tasks.ForEach(task =>
        {
            var assignee = Employees.Find(x => x.Id == task.Assignee.Id);
            if (assignee != null && assignee != task.Assignee)
            {
                task.Assignee = assignee;
            }
        });
    }
}


/*
Этап 2. Работа с сущностями

Добавить модуль для работы с задачами.

Так же требуется добавить в модуль для работы с файлами следующий функционал:
Добавление новых сотрудников
Добавление новых задач
Обновление сотрудников
Обновление задач
Обновленные данные требуется записывать в хранилище в том же формате, в котором они изначально там лежали
*/
/*
Всем категориям пользователей, кроме Бухгалтера:
Создавать задачу +

Назначать исполнителем этой задачи либо себя, +
либо сотрудника, начальником которого этот пользователь является

Редактировать свою задачу следующим образом:
Менять ее статус. Обратите внимание, +
что сама Задача не должна позволять поставить статус Закрыта до тех пор,
пока есть подзадачи НЕ в статусе Закрыта

Менять ее Риск +

Добавлять новую подзадачу +

Менять пароль всем сотрудникам, начальником которого он является +

Администратору:
Менять пароль любому сотруднику
Создавать задачу и назначать исполнителем кого угодно
Создавать новых сотрудников и назначать им Начальников
 */