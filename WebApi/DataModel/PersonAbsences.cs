using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class PersonAbsences
    {
        public int Id { get; set; }
        public int EducationalCenterId { get; set; }
        public int PersonId { get; set; }
        public DateTime? DateAbsences { get; set; }
        public int? ClassId { get; set; }
        public string Note { get; set; }
        public string CreateUser { get; set; }
        public string LastModeUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }

        public Classes Class { get; set; }
        public EducationalCenters EducationalCenter { get; set; }
        public Person Person { get; set; }
    }
}
