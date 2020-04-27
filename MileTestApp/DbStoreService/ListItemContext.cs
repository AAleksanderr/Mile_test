using System.Data.Entity;
using SolutionPreferences.Models;

namespace DbStoreService
{
    public class ListItemContext : DbContext
    {
        public ListItemContext() : base("MileTestAppDb")
        {
        }

        public DbSet<ListItem> Items { get; set; }
    }
}