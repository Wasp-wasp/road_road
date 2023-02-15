using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Highways
    {
        public Highways()
        {
            Place = new HashSet<Place>();
        }

        public int IdHighway { get; set; }
        public string NameOfHighway { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }
}
