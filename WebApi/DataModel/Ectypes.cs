using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class Ectypes
    {
        public Ectypes()
        {
            EducationalCenters = new HashSet<EducationalCenters>();
        }

        public int EctypeId { get; set; }
        public string TypeCode { get; set; }
        public string TypeAr { get; set; }
        public string TypeEn { get; set; }

        public ICollection<EducationalCenters> EducationalCenters { get; set; }
    }
}
