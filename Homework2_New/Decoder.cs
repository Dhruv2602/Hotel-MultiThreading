using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_New
{
    class Decoder
    {
        public static OrderClass Decode(string s)
        {
            string[] words = s.Split(',');
            OrderClass order = new OrderClass(Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), Convert.ToInt32(words[2]), Convert.ToInt32(words[3]));
            return order;
        }
    }
}
