using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class MessagesTypes
    {
        public MessagesTypes()
        {
            Messages = new HashSet<Messages>();
        }

        public int MessageTypeId { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public string DefaultTitle { get; set; }
        public string TextEn { get; set; }
        public string TextAr { get; set; }
        public string TextFr { get; set; }

        public ICollection<Messages> Messages { get; set; }
    }
}
