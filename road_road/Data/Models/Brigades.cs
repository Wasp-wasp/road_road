using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Brigades
    {
        public Brigades()
        {
            Tasks = new HashSet<Tasks>();
            Workers = new HashSet<Workers>();
        }

        public int IdBrigade { get; set; }
        public string NameOfBrigade { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
