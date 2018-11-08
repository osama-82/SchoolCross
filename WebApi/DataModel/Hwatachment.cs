using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class Hwatachment
    {
        public int Id { get; set; }
        public int? HwId { get; set; }
        public string AttcName { get; set; }
        public string AttLink { get; set; }
        public string Guid { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string LastModUserId { get; set; }
        public DateTime? LastModDate { get; set; }
        public bool? Deleted { get; set; }
        public string Domain { get; set; }
        public int? CenterId { get; set; }
        public string Note { get; set; }
        public bool? Active { get; set; }

        public HomeWork Hw { get; set; }
    }
}
