using System;
using System.Collections.Generic;

namespace DemoWebApp.Model
{
    public class Client
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Account> Accounts { get; protected set; }
        public DateTime CreatedOn { get; set; }

        public Client()
        {
            Accounts = new List<Account>();
            CreatedOn = DateTime.Now;
        }
    }
}