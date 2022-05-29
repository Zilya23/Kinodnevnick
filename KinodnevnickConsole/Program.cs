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
                Console.WriteLine("3) Посмотреть статистику пользователя");
                Console.WriteLine("4) Вывести все награды");
                Console.WriteLine("5) Таблица лидеров");
                Console.WriteLine("6) Посмотреть меню функций");
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

                    case "3":
                            Console.WriteLine("Введите имя пользователя");
                            string user_ = Console.ReadLine().Trim();
                            ObservableCollection<User> _user = Authorization.SearchUser(user_);
                            if (_user.Count == 1)
                            {
                                Console.WriteLine("Найден пользователь");
                                User user = new User();
                                foreach (var i in _user)
                                {
                                    Console.WriteLine(i.Nickname);
                                    user = i;
                                }
                                int staistic = StatisticFunction.CountTimeViewedFilm(user.ID);
                                Console.WriteLine("Всего потрачено времени на просмотр: " + staistic);
                                staistic = StatisticFunction.CountViewedFilm(user.ID);
                                Console.WriteLine("Всего фильмов просмотрено: " + staistic);
                                staistic = StatisticFunction.CountDoneTest(user.ID);
                                Console.WriteLine("Всего тестов пройдено: " + staistic);
                                staistic = StatisticFunction.CountAward(user.ID);
                                Console.WriteLine("Количество полученных наград: " + staistic);
                                staistic = StatisticFunction.GetUserLevel(user).ID;
                                Console.WriteLine("Уровень пользователя: " + staistic);
                                staistic = StatisticFunction.RatingUser(user.ID);
                                Console.WriteLine("Место в рейтинге: " + staistic);
                            }
                            else if (_user.Count > 1)
                            {
                                Console.WriteLine("Найдено:");
                                foreach (var i in _user)
                                {
                                    Console.WriteLine(i.ID + ") " + i.Nickname);
                                }
                                Console.WriteLine("Выберите номер пользователя");
                                int userId = Convert.ToInt32(Console.ReadLine());
                                foreach (var i in _user)
                                {
                                    if (i.ID == userId)
                                    {
                                        int staistic = StatisticFunction.CountTimeViewedFilm(userId);
                                        Console.WriteLine("Всего потрачено времени на просмотр: " + staistic);
                                        staistic = StatisticFunction.CountViewedFilm(userId);
                                        Console.WriteLine("Всего фильмов просмотрено: " + staistic);
                                        staistic = StatisticFunction.CountDoneTest(userId);
                                        Console.WriteLine("Всего тестов пройдено: " + staistic);
                                        staistic = StatisticFunction.CountAward(userId);
                                        Console.WriteLine("Количество полученных наград: " + staistic);
                                        staistic = StatisticFunction.GetUserLevel(i).ID;
                                        Console.WriteLine("Уровень пользователя: " + staistic);
                                        staistic = StatisticFunction.RatingUser(userId);
                                        Console.WriteLine("Место в рейтинге: " + staistic);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пользователь не найден");
                            }
                        break;
                        case "4":
                            ObservableCollection<Award> awards = AwardFunction.GetAwards();
                            foreach (var i in awards)
                            {
                                Console.WriteLine(i.Name + " - " + i.Description);
                            }
                        break;
                        case "5":
                            List<User> leaderboard = FriendFunction.GetLeader();
                            int plase = 1;
                            Console.WriteLine("Место" + " " + "Никнейм" + " " + "Очки");
                            foreach (var i in leaderboard)
                            {
                                Console.WriteLine("  " + plase + "   " + i.Nickname + "  " + i.Count_XP);
                                plase++;
                            }
                        break;
                        case "6":
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
