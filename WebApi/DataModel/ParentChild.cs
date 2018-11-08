using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class ParentChild
    {
        public int ParentChildId { get; set; }
        public int ParentPersonId { get; set; }
        public int ChildPersonId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public string LastModifiedUser { get; set; }

        public Person ChildPerson { get; set; }
        public ParentChild ParentChildNavigation { get; set; }
        public Person ParentPerson { get; set; }
        public ParentChild InverseParentChildNavigation { get; set; }
    }
}
