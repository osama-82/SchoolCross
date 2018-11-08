using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class CurriculumItem
    {
        public CurriculumItem()
        {
            SchoolSchedule = new HashSet<SchoolSchedule>();
            StudentCurriculumGrade = new HashSet<StudentCurriculumGrade>();
        }

        public int Id { get; set; }
        public int EducationalCenterId { get; set; }
        public int? OrderId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public EducationalCenters EducationalCenter { get; set; }
        public ICollection<SchoolSchedule> SchoolSchedule { get; set; }
        public ICollection<StudentCurriculumGrade> StudentCurriculumGrade { get; set; }
    }
}
