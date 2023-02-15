using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Workers
    {
        public int IdWorker { get; set; }
        public int? IdPosition { get; set; }
        public int? IdGender { get; set; }
        public int? IdBrigade { get; set; }
        public DateTime? DateOfBers { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephon { get; set; }
        public string EMail { get; set; }
        public string Photo { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Brigades IdBrigadeNavigation { get; set; }
        public virtual Genders IdGenderNavigation { get; set; }
        public virtual Positions IdPositionNavigation { get; set; }
    }
}
