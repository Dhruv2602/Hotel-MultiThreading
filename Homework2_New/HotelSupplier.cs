using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework2_New
{
    class HotelSupplier
    {
        public delegate void priceCutDelegate(int id);
        public event priceCutDelegate priceCut;

        public delegate void supplierDeadDelegate();
        public event supplierDeadDelegate supplierDead;

        int p = 0; //increment on price cut
        int min_price = Int32.MaxValue;
        int supplier_id;

        public HotelSupplier(int id)
        {
            this.supplier_id = id;
        }

        public int PricingModel()
        {
            int r = StaticRandom.Rand()%6000;
            while(r<5000)
            {
                r += 5000;
                r %= 6000;
            }
            return r;
        }

        public void supplierThread()
        {
            while (p != 5)
            {
                int price = PricingModel();
                if (price < min_price)
                {
                    min_price = price;
                    p += 1;
                    //Console.WriteLine("p = " + p);
                    Console.WriteLine("\nPrice has been cut to " + price + " for Hotel Supplier ID: " + supplier_id + "\n");
                    priceCut(supplier_id);
                    Thread.Sleep(10000);
                }
            }
            supplierDead();
        }

        public void getterThread()
        {
            //while (p != 10)
            while(true)
                getOrder(supplier_id);
        }

        public void getOrder(int supid)
        {
            string o = Program.bo.getOneCell();
            OrderClass order = Decoder.Decode(o);
            double amount = OrderProcessing.processOrder(order, min_price);
            //Console.WriteLine("Received Order " + o + " from Buffer\n");
        }
    }
}
