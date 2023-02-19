using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using road_road.Data.Models;

namespace road_road.View
{
    //работа с бд
    class AuthenticationService
    {
        static private DBContext context = new DBContext();
        public static bool Avtorisation(string login, string pass)
        {
            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == pass);
            if (user != null) return true;
            return false;
        }

        public static IEnumerable<Genders> GenderID()
        {
            var gender = context.Genders.ToList();
            return gender;
        }

        public static bool Registration(Users users)
        {
            context.Users.Add(users);
            context.SaveChanges();
            return true;
        }
    }
}
