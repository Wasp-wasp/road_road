using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Place
    {
        public Place()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int IdPlace { get; set; }
        public int? IdTown { get; set; }
        public int? IdHighway { get; set; }
        public int? IdStreet { get; set; }
        public string PlaceDiscription { get; set; }

        public virtual Highways IdHighwayNavigation { get; set; }
        public virtual Streets IdStreetNavigation { get; set; }
        public virtual Towns IdTownNavigation { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
