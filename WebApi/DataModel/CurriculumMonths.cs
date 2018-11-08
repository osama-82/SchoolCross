using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class CurriculumMonths
    {
        public CurriculumMonths()
        {
            StudentCurriculumGrade = new HashSet<StudentCurriculumGrade>();
        }

        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int MonthCodeId { get; set; }
        public int? MonthTypeCodeId { get; set; }
        public int EducationalCenterId { get; set; }

        public EducationalCenters EducationalCenter { get; set; }
        public MonthsCode MonthCode { get; set; }
        public MonthsTypeCode MonthTypeCode { get; set; }
        public ICollection<StudentCurriculumGrade> StudentCurriculumGrade { get; set; }
    }
}
