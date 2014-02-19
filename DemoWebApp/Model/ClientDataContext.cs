using System.Data.Entity;

namespace DemoWebApp.Model
{
    public class ClientDataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }

        static ClientDataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ClientDataContext>());
        }

        public ClientDataContext()
        {
        }

        public ClientDataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}