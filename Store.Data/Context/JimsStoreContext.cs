using Store.Core;
using Store.Core.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class JimsStoreContext : DbContext
    {

        public JimsStoreContext(string connectionString) : base(connectionString)
        {
          
        }

        public DbSet<Pencil> Pencils { get; set; }
        public DbSet<Buyer> Buyers { get; set; } 

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
