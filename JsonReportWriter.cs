using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace ConsoleApp1
{
    public static class JsonReportWriter<T>
    {
        public static void Write(T report)
        {
            var file = new StreamWriter($"{typeof(T).Name}.txt");
            file.Write(JsonSerializer.Serialize(report, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            }));
            file.Close();
        }
    }
}
