using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class DaysCode
    {
        public DaysCode()
        {
            SchoolSchedule = new HashSet<SchoolSchedule>();
        }

        public int DayId { get; set; }
        public string DayNameAr { get; set; }
        public string DayNameEn { get; set; }
        public int? OrderId { get; set; }

        public ICollection<SchoolSchedule> SchoolSchedule { get; set; }
    }
}
