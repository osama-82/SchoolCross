using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class Departments
    {
        public Departments()
        {
            Classes = new HashSet<Classes>();
        }

        public int DepartmentId { get; set; }
        public int EducationalCenterId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDesc { get; set; }
        public bool? Deleted { get; set; }

        public EducationalCenters EducationalCenter { get; set; }
        public ICollection<Classes> Classes { get; set; }
    }
}
