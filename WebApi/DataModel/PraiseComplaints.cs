using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class PraiseComplaints
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public DateTime? DateAdd { get; set; }
        public string CreatedUser { get; set; }
        public bool? Deleted { get; set; }

        public AspNetUsers User { get; set; }
    }
}
