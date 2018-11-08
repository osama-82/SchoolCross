using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class ClassPerson
    {
        public int ClassPersonId { get; set; }
        public int ClassId { get; set; }
        public int PersonId { get; set; }

        public Classes Class { get; set; }
        public Person Person { get; set; }
    }
}
