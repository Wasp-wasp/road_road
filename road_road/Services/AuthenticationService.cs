using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using road_road.Data.Models;
using Z.EntityFramework.Plus;

namespace road_road.View
{
    //работа с бд
    class AuthenticationService
    {
        static private DBContext context = new DBContext();
        public static bool Autorisation(string login, string pass)
        {
            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == pass);
            if (user != null) return true;
            return false;
        }

        /*public static string Load_data(string login)
        {
            var user = context.Users.SingleOrDefault(x => x.Login == login);
            return user.ToString();
        }*/

        public static bool Login_UQ(string login)
        {
            var log = context.Users.Where(x => x.Login == login).SingleOrDefault();
            if (log == null) return true;
            return false;

            //var log = context.Users.SingleOrDefault(x => x.Login != login);
            //if (log != null) return true;
            //return false;
        }

        public static IEnumerable<Genders> GenderID()
        {
            var gender = context.Genders.ToList();
            return gender;
        }
        public static IEnumerable<string> BrigadeID()
        {
            var brigade = context.Brigades.Select(x => x.NameOfBrigade).ToList();
            return brigade;
        }

        public static IEnumerable<TypeTask> TaskID()
        {
            var task = context.TypeTask.ToList();
            return task;
        }

        public static bool Registration(Users users)
        {
            context.Users.Add(users);
            context.SaveChanges();
            return true;
        }

        public static bool Edit_Profile(Users user, string login)
        {
            context.Users.Where(x => x.Login == login).SingleOrDefault();
            context.UpdateRange(user);
            context.SaveChanges();
            return true;
        }


        //public static bool IEnumerable<Users> Users
        //{
        //    var users = context.Users.ToList();
        //    return users;
        //}

        public static IEnumerable<int> WT(string Title)
        {
            int title = Convert.ToInt32(Title);
            //var brigade = context.Brigades.Select(x => x.IdBrigade);
            //var id_brigades = context.Brigades.Select(x => x.IdBrigade == BrigadeID).;
            var wt = context.Tasks

                /*.Select(x => new
                {
                    BrigadeID = x.IdBriade,
                    Task = x.IdTask
                }
                )
                .GroupBy(b => b.BrigadeID)
                .OrderBy(c => c.Key) //key  сортировка по возрастанию ID
                .Select(j => j.Count())
                ;*/
                .Where(c => c.DateTimeBegin >= new DateTime(title / 01 / 01) && c.DateTimeEnd >= new DateTime(title / 31 / 01))
                .Select(x => new
                {
                    BrigadeID = x.IdBriade,
                    Days = x.DateTimeEnd.DayOfYear - x.DateTimeBegin.DayOfYear + 1
                }
                )
                .GroupBy(b => b.BrigadeID)
                .OrderBy(c => c.Key) //key  сортировка по возрастанию ID
                .Select(j => j.Sum(t => t.Days))
                ;

             return wt;
        }

    }
}
