using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
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
        public static IEnumerable<string> BrigadeID(string title)
        {

            //var brigade = context.Brigades.Select(x => x.NameOfBrigade).ToList();
            //return brigade;
            
            string titleBegin = title + "-01-01";
            string titleEnd = title + "-12-31";

            var SortBrigName = context.Tasks.Join(context.Brigades,
                t => t.IdBrigade, 
                b => b.IdBrigade, 
                (t, b) => new { Task = t, Brigade = b })
                .Where(tb => tb.Task.DateTimeBegin >= DateTime.Parse(titleBegin) && tb.Task.DateTimeEnd <= DateTime.Parse(titleEnd))
                .Select(tb => tb.Brigade.NameOfBrigade)
                .Distinct();
            //var result = from t in context.Tasks
            //             join b in context.Brigades on t.IdBrigade equals b.IdBrigade
            //             where t.DateTimeBegin >= DateTime.Parse(titleBegin) && t.DateTimeEnd <= DateTime.Parse(titleEnd)
            //             select b.NameOfBrigade;
            SortBrigName.ToList();
            return SortBrigName;

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

        public static IEnumerable<int> WT(string title)
        {
            string titleBegin = title + "-01-01";
            string titleEnd = title + "-12-31";
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
                
                .Select(x => new
                {
                    dateTimeBegin = x.DateTimeBegin,
                    dateTimeEnd  = x.DateTimeEnd,
                    BrigadeID = x.IdBrigade,
                    Days = x.DateTimeEnd.DayOfYear - x.DateTimeBegin.DayOfYear + 1
                }
                )
                .Where(c => c.dateTimeBegin >= DateTime.Parse(titleBegin) && c.dateTimeEnd <= DateTime.Parse(titleEnd))
                .GroupBy(b => b.BrigadeID)
                .OrderBy(c => c.Key) //key  сортировка по возрастанию ID
                .Select(j => j.Sum(t => t.Days))
                ;

             return wt;
        }

    }
}
