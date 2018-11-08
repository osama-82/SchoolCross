using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class Classes
    {
        public Classes()
        {
            ClassPerson = new HashSet<ClassPerson>();
            PersonAbsences = new HashSet<PersonAbsences>();
            SchoolSchedule = new HashSet<SchoolSchedule>();
        }

        public int ClassId { get; set; }
        public int EducationalCenterId { get; set; }
        public int? DepartmentId { get; set; }
        public string Guid { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string Note { get; set; }
        public bool? Deleted { get; set; }

        public Departments Department { get; set; }
        public EducationalCenters EducationalCenter { get; set; }
        public ICollection<ClassPerson> ClassPerson { get; set; }
        public ICollection<PersonAbsences> PersonAbsences { get; set; }
        public ICollection<SchoolSchedule> SchoolSchedule { get; set; }
    }
}
