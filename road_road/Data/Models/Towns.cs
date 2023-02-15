using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Place = new HashSet<Place>();
        }

        public int IdTown { get; set; }
        public string NameOfTown { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }
}
