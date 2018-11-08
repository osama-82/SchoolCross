using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class AccountsTypes
    {
        public AccountsTypes()
        {
            Person = new HashSet<Person>();
        }

        public int AccountTypeId { get; set; }
        public string Type { get; set; }
        public string TypeAr { get; set; }
        public bool? Active { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}
