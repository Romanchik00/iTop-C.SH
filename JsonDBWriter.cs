using ConsoleApp1.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ConsoleApp1
{
    public static class JsonDBWriter
    {
        public static void WriteJsonFile(List<Employee> employees)
        {
            var json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), WriteIndented = true });
            File.WriteAllText("People.txt", json);
        }
        public static void WriteJsonFile(List<myTask> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), WriteIndented = true });
            File.WriteAllText("Tasks.txt", json);
        }
    }
}