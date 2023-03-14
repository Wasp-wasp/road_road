using System;
using road_road.Data.Models;


namespace road_road.Data.DTO
{
    class TaskViewModel
    {
        public int IdTask { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string NameTypeTask { get; set; }
        public string NameObject { get; set; }
        public string Town { get; set; }
        public string Highway { get; set; }
        public string Street { get; set; }
        public string NameMaterial { get; set; }
        public string NameTechnic { get; set; }
        public string NameBrigade { get; set; }
        public virtual Place IdPlaceNavigation { get; set; }

    }
}
