using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class SchoolSchedule
    {
        public int SchoolScheduleId { get; set; }
        public int EducationalCenterId { get; set; }
        public int ClassId { get; set; }
        public int CurricclumItemId { get; set; }
        public int DayId { get; set; }
        public DateTime ItemTime { get; set; }

        public Classes Class { get; set; }
        public CurriculumItem CurricclumItem { get; set; }
        public DaysCode Day { get; set; }
        public EducationalCenters EducationalCenter { get; set; }
    }
}
