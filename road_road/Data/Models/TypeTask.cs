using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class TypeTask
    {
        public TypeTask()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int IdTypeTask { get; set; }
        public string NameTypeTask { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
