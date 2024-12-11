using System.Text.Json;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public static class JsonReader
    {
        public static List<Employee> EmployeeListRead(string file)
        {
            List<Employee> list = new();
            list = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(file));
            return list;
        }
        public static List<Models.myTask> TaskListRead(string file)
        {
            List<Models.myTask> list = new();
            list = JsonSerializer.Deserialize<List<Models.myTask>>(File.ReadAllText(file));
            return list;
        }
    }
}
