using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class Settings
    {
        public int SettingId { get; set; }
        public string UserId { get; set; }
        public string Lang { get; set; }
        public int? StatusId { get; set; }
    }
}
