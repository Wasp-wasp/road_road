using System;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Users
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }
        public int? IdGender { get; set; }
        public DateTime? DateOfBers { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string EMail { get; set; }
        public string Photo { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Genders IdGenderNavigation { get; set; }
        public virtual Roles IdRoleNavigation { get; set; }

        
    }
}
