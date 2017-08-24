using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JimsStoreContext>
    {
        protected override void Seed(JimsStoreContext context)
        {
            var buyes = new List<Buyer>
            {
            new Buyer{BuyerName="Jim"},
            new Buyer{BuyerName="Jill"},
            new Buyer{BuyerName="Jack"} };

            buyes.ForEach(s => context.Buyers.Add(s));
            context.SaveChanges();


        }
    }
}
