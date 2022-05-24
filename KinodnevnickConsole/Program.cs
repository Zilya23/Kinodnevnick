using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core;
using Core.DateBase;

namespace KinodnevnickConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение для ведения кинодневника \"Кинокрад\"!");
            while(true)
            {
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
                            ObservableCollection<User> users = Authorization.SearchUser(username);
                            if (users.Count == 1)
                            {
                                Console.WriteLine("Найден пользователь");
                                User user = new User();
                                foreach (var i in users)
                                {
                                    Console.WriteLine(i.Nickname);
                                    user = i;
                                }
                                ObservableCollection<Collection> friendcoll = CollectionFunction.GetFriendCollection(user.ID);
                                foreach (var coll in friendcoll)
                                {
                                    Console.WriteLine(coll.Name);
                                }
                            }
                            else if (users.Count > 1)
                            {
                                Console.WriteLine("Найдено:");
                                foreach (var i in users)
                                {
                                    Console.WriteLine(i.ID + ") " + i.Nickname);
                                }
                                Console.WriteLine("Выберите номер пользователя");
                                int userId = Convert.ToInt32(Console.ReadLine());
                                foreach (var i in users)
                                {
                                    if(i.ID == userId)
                                    {
                                        ObservableCollection<Collection> friendcoll = CollectionFunction.GetFriendCollection(i.ID);
                                        foreach (var coll in friendcoll)
                                        {
                                            Console.WriteLine(coll.Name);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пользователь не найден");
                            }
                            break;
                    case "2":
                            Console.WriteLine("Введите название фильма");
                            string filmname = Console.ReadLine().Trim();
                            if(filmname != "")
                            {
                                ObservableCollection<Film> searchFilms = FilmFunction.SearchFilm(filmname);
                                if(searchFilms.Count != 0)
                                {
                                    foreach(var i in searchFilms)
                                    {
                                        Console.WriteLine(i.ID + ") " + i.Name);
                                    }
                                    Console.WriteLine("Введите номер подходящего фильма");
                                    int filmId = Convert.ToInt32(Console.ReadLine());
                                    foreach (var i in searchFilms)
                                    {
                                        if(i.ID == filmId)
                                        {
                                            Console.WriteLine("Название: " + i.Name);
                                            Console.WriteLine("Дата выхода: " + i.Date_Issue);
                                            Console.WriteLine("Длительность в мин: " + i.Duration);
                                            Console.WriteLine("Описание: " + i.Description);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Фильм не найден");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Фильм не найден");
                            }
                        break;
                    default:
                        Console.WriteLine("Действие не найдено, повторите попытку");
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
}
