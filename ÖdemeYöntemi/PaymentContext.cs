using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖdemeYöntemi
{
    public class PaymentContext : DbContext
    {
        public PaymentContext() : base("name=YourDbConnectionString") { }
        public DbSet<PaymentModel> Payments { get; set; }
    }
}
