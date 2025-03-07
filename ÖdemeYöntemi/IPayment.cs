using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖdemeYöntemi
{
    public interface IPayment
    {
        void ProcessPayment(string amount);
    }
}
