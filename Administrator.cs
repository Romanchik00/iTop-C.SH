using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Administrator
    {
        public CurrentConfiguration CurrentConfiguration { get; private set; }
        private Administrator(Employee employee)
        {
            CurrentConfiguration = new();
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
        public static Administrator? Auth()
        {
            Console.WriteLine("Введите логин и пароль (одной строкой)");
            var str = Console.ReadLine();
            if (str != null)
            {
                var logpass = str.Split(" ");
                if (logpass.Length < 2)
                {
                    Console.WriteLine("Ошибка: отсутствует логин или пароль");
                    return null;
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
                        return new Administrator(employee);
                    }
                    else
                    {
                        Console.WriteLine("Такого пользователя не существует");
                        return null;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка: ввод пустой строки");
                return null;
            }
        }
    }
}
