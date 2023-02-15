using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Genders
    {
        public Genders()
        {
            Users = new HashSet<Users>();
            Workers = new HashSet<Workers>();
        }

        public int IdGender { get; set; }
        public string NameOfGender { get; set; }

        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
