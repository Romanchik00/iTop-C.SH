using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class AuthManager
    {
        //public CurrentConfiguration? CurrentConfiguration { get; private set; } = null;

        public void Auth()
        {
            Console.WriteLine("Введите логин и пароль (одной строкой)");
            var str = Console.ReadLine();
            if (str != null)
            {
                var logpass = str.Split(" ");
                if (logpass.Length < 2)
                {
                    Console.WriteLine("Ошибка: отсутствует логин или пароль");
                }
                else
                {
                    var employee = JsonReader.EmployeeListRead("People.txt").Find(x =>
                    {
                        if (x.Login == logpass[0] && x.Password == logpass[1]) { return true; }
                        return false;
                    });
                    if (employee != null)
                    {
                        CurrentConfiguration.CurrentUser = new Employee
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            Position = employee.Position,
                            Login = employee.Login,
                            Password = employee.Password,
                            SupervisorId = employee.SupervisorId
                        };
                    }
                    else
                    {
                        Console.WriteLine("Такого пользователя не существует");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка: ввод пустой строки");
            }
        }
    }
}
