using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class MonthsCode
    {
        public MonthsCode()
        {
            CurriculumMonths = new HashSet<CurriculumMonths>();
        }

        public int MonthCodeId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }

        public ICollection<CurriculumMonths> CurriculumMonths { get; set; }
    }
}
