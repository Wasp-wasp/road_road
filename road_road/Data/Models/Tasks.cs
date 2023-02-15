using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class Tasks
    {
        public int IdTask { get; set; }
        public int? IdTypeTask { get; set; }
        public int? IdObject { get; set; }
        public int? IdPlace { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdTechnic { get; set; }
        public int? IdBriade { get; set; }
        public DateTime? DateTimeBegin { get; set; }
        public DateTime? DateTimeEnd { get; set; }

        public virtual Brigades IdBriadeNavigation { get; set; }
        public virtual Materials IdMaterialNavigation { get; set; }
        public virtual Objects IdObjectNavigation { get; set; }
        public virtual Place IdPlaceNavigation { get; set; }
        public virtual Technics IdTechnicNavigation { get; set; }
        public virtual TypeTask IdTypeTaskNavigation { get; set; }
    }
}
