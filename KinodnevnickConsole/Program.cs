using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.DateBase;

namespace KinodnevnickConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение для ведения кинодневника \"Кинокрад\"!");
            Console.WriteLine("Что бы вы хотели сделать?");
            Console.WriteLine("1) Посмотреть коллекции пользователей");
            Console.WriteLine("2) Посмотреть информацию о фильме");
            Console.WriteLine("3) Посмотреть меню функций");
            Console.WriteLine("Введите номер действия");
            try
            {
                string action = Console.ReadLine().Trim();
                switch (action)
                {
                    case "1":
                        Console.WriteLine("Введите имя пользователя");
                        string username = Console.ReadLine().Trim();
                        break;
                    case "2":
                        Console.WriteLine("Введите название фильма");
                        string filmname = Console.ReadLine().Trim();
                        break;
                    case "3":
                        Console.WriteLine("Что бы вы хотели сделать?");
                        Console.WriteLine("1) Посмотреть коллекции пользователей");
                        Console.WriteLine("2) Посмотреть информацию о фильме");
                        Console.WriteLine("3) Посмотреть меню функций");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Действие не найдено, повторите попытку");
            }
        }
    }
}
