using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class Messages
    {
        public int MessageId { get; set; }
        public int? EducationalCenterId { get; set; }
        public int? LinkedMessageId { get; set; }
        public int? MessageTypeId { get; set; }
        public int FromPersonId { get; set; }
        public int ToPersonId { get; set; }
        public string Title { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }
        public bool? Deleted { get; set; }
        public string Domain { get; set; }

        public EducationalCenters EducationalCenter { get; set; }
        public Person FromPerson { get; set; }
        public Messages Message { get; set; }
        public MessagesTypes MessageType { get; set; }
        public Person ToPerson { get; set; }
        public Messages InverseMessage { get; set; }
    }
}
