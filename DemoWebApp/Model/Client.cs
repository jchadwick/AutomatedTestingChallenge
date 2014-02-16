﻿using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DemoWebApp.Model
{
    public class Client
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Account> Accounts { get; set; }
        public DateTime CreatedOn { get; set; }

        public Client()
        {
            CreatedOn = DateTime.Now;
        }
    }

    public class ClientDataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }

        public ClientDataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ClientDataContext>());
        }
    }

}