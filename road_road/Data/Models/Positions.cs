using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Workers = new HashSet<Workers>();
        }

        public int IdPosition { get; set; }
        public string NameOfPosition { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }
    }
}
