using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_New
{
    class Encoder
    {
        public static string Encode(OrderClass order)
        {
            string s = order.getSenderId().ToString() + "," + order.getCardNo().ToString() + "," + order.getReceiverID().ToString() + "," + order.getAmount().ToString();
            return s;
        }
    }
}
