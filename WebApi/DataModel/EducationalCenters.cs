using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class EducationalCenters
    {
        public EducationalCenters()
        {
            Classes = new HashSet<Classes>();
            CurriculumItem = new HashSet<CurriculumItem>();
            CurriculumMonths = new HashSet<CurriculumMonths>();
            Departments = new HashSet<Departments>();
            Messages = new HashSet<Messages>();
            Person = new HashSet<Person>();
            PersonAbsences = new HashSet<PersonAbsences>();
            SchoolSchedule = new HashSet<SchoolSchedule>();
            StudentCurriculumGrade = new HashSet<StudentCurriculumGrade>();
        }

        public int EducationalCenterId { get; set; }
        public int? EctypeId { get; set; }
        public string GuidId { get; set; }
        public string CenterName { get; set; }
        public string CenterCode { get; set; }
        public string CenterDesc { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressCity { get; set; }
        public string AddressState { get; set; }
        public string Country { get; set; }
        public string CenterPicUrl { get; set; }
        public string CenterWebUrl { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? LastModeDate { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public bool? InProd { get; set; }

        public Ectypes Ectype { get; set; }
        public ICollection<Classes> Classes { get; set; }
        public ICollection<CurriculumItem> CurriculumItem { get; set; }
        public ICollection<CurriculumMonths> CurriculumMonths { get; set; }
        public ICollection<Departments> Departments { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public ICollection<Person> Person { get; set; }
        public ICollection<PersonAbsences> PersonAbsences { get; set; }
        public ICollection<SchoolSchedule> SchoolSchedule { get; set; }
        public ICollection<StudentCurriculumGrade> StudentCurriculumGrade { get; set; }
    }
}
