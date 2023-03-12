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


        public static bool Login_UQ(string login)
        {
            var log = context.Users.Where(x => x.Login == login).SingleOrDefault();
            if (log == null) return true;
            return false;
        }

        public static IEnumerable<Genders> GenderID()
        {
            var gender = context.Genders.ToList();
            return gender;
        }
        public static IEnumerable<Roles> RoleID()
        {
            var role = context.Roles.ToList();
            return role;
        }

        public static IEnumerable<string> BrigadeID(string title)
        {
            string titleBegin = title + "-01-01";
            string titleEnd = title + "-12-31";

            var SortBrigName = context.Tasks.Join(context.Brigades,
                t => t.IdBrigade, 
                b => b.IdBrigade, 
                (t, b) => new { Task = t, Brigade = b })
                .Where(tb => tb.Task.DateTimeBegin >= DateTime.Parse(titleBegin) && tb.Task.DateTimeEnd <= DateTime.Parse(titleEnd))
                .Select(tb => tb.Brigade.NameOfBrigade)
                .Distinct();
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

        public static IEnumerable<int> WT(string title)
        {
            string titleBegin = title + "-01-01";
            string titleEnd = title + "-12-31";
            var wt = context.Tasks
                
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
