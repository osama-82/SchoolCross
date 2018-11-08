using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class StudentCurriculumGrade
    {
        public int StCurriculumGradeId { get; set; }
        public int EducationalCenterId { get; set; }
        public int PersonId { get; set; }
        public int CurriculumMonthId { get; set; }
        public int CurriculumItemId { get; set; }
        public int? Grade { get; set; }

        public CurriculumItem CurriculumItem { get; set; }
        public CurriculumMonths CurriculumMonth { get; set; }
        public EducationalCenters EducationalCenter { get; set; }
        public Person Person { get; set; }
    }
}
