using System.Data.Entity;
using SolutionPreferences.Models;
using SolutionPreferences.StorageServiceSettings;

namespace DbStoreService
{
    public class ListItemContext : DbContext
    {
        public ListItemContext() : base(Connection.ConnectionString)
        {
        }

        public DbSet<ListItem> Items { get; set; }
    }
}