using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class MonthsTypeCode
    {
        public MonthsTypeCode()
        {
            CurriculumMonths = new HashSet<CurriculumMonths>();
        }

        public int MonthTypeCodeId { get; set; }
        public string TypeDesc { get; set; }
        public string TypeCode { get; set; }

        public ICollection<CurriculumMonths> CurriculumMonths { get; set; }
    }
}
