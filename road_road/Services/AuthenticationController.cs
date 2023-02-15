using System.Linq;
using road_road.Data.Models;

namespace road_road.View
{
    class AuthenticationController
    {
        static private DBContext context = new DBContext();
        public static bool Avtorisation(string login, string pass)
        {
            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == pass);
            if (user != null) return true;
            return false;
        }
        
        public static bool Registration(Users users)
        {
            //TODO
            return true;
        }
    }
}
