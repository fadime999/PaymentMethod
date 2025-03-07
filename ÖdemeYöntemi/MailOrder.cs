using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖdemeYöntemi
{
    public class MailOrder : IPayment
    {
        public void ProcessPayment(string amount)
        {
            using (var context = new PaymentContext())
            {
                context.Payments.Add(new PaymentModel { PaymentType = "Mail Order", Amount = Convert.ToDecimal(amount) });
                context.SaveChanges();
            }
        }
    }

}
