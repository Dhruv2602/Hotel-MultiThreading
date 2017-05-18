using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework2_New
{
    class TravelAgency
    {
        bool priceCut = false, supplierActive = true;
        int supplier_id;
        int agency_id;
        DateTime t1;

        public void subscribe(List<HotelSupplier> HotelSuppliers)
        {
            for (int i = 0; i < 2; i++)
            {
                HotelSuppliers[i].priceCut += this.priceCutCallback;
                HotelSuppliers[i].supplierDead += this.supplierDeadCallback;
                OrderProcessing.orderCompleted += this.confirmOrder;
            }
        }

        public int numberOfRoomsToOrder()
        {
            return StaticRandom.Rand() % 100;
        }

        public void priceCutCallback(int supplier_id)
        {
            this.supplier_id = supplier_id;
            priceCut = true;
        }

        public void supplierDeadCallback()
        {
            supplierActive = false;
        }

        public void agencyThread(int agency_id, int cardNo)
        {
            this.agency_id = agency_id;
            while (supplierActive)
            {
                while (!priceCut)
                { }

                int rooms = numberOfRoomsToOrder(); 
                OrderClass order = new OrderClass(agency_id, cardNo, supplier_id, rooms);
                string encoded = Encoder.Encode(order);
                t1 = DateTime.Now;
                Program.bo.setOneCell(encoded);
                priceCut = false;
                Thread.Sleep(1000);
            }
        }

        public void confirmOrder(int ag_id, int sup_id)
        {
            if (ag_id == agency_id)
            {
                DateTime t2 = DateTime.Now;
                Console.WriteLine("Milliseconds to process order: " + t2.Subtract(t1).TotalMilliseconds);
                Console.WriteLine("Order Confirmed from Travel Agency ID: " + ag_id);
            }
        }
    }
}
