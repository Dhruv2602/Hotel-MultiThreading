using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework2_New
{
    class Program
    {
        public static MultiCellBuffer bo = new MultiCellBuffer();
        static void Main(string[] args)
        {
            List<HotelSupplier> HotelSupplierObj = new List<HotelSupplier>();
            HotelSupplierObj.Add(new HotelSupplier(1));
            HotelSupplierObj.Add(new HotelSupplier(2));

            List<TravelAgency> TravelAgencyObj = new List<TravelAgency>();
            TravelAgencyObj.Add(new TravelAgency());
            TravelAgencyObj.Add(new TravelAgency());
            TravelAgencyObj.Add(new TravelAgency());
            TravelAgencyObj.Add(new TravelAgency());
            TravelAgencyObj.Add(new TravelAgency());

            List<Thread> TravelAgencyThread = new List<Thread>();
            TravelAgencyThread.Add(new Thread(() => TravelAgencyObj[0].agencyThread(10, 5000)));
            TravelAgencyThread.Add(new Thread(() => TravelAgencyObj[1].agencyThread(20, 6000)));
            TravelAgencyThread.Add(new Thread(() => TravelAgencyObj[2].agencyThread(30, 7000)));
            TravelAgencyThread.Add(new Thread(() => TravelAgencyObj[3].agencyThread(40, 8000)));
            TravelAgencyThread.Add(new Thread(() => TravelAgencyObj[4].agencyThread(50, 9000)));

            TravelAgencyThread[0].Start();
            TravelAgencyThread[1].Start();
            TravelAgencyThread[2].Start();
            TravelAgencyThread[3].Start();
            TravelAgencyThread[4].Start();

            foreach (var item in TravelAgencyObj)
            {
                item.subscribe(HotelSupplierObj);
            }

            Thread t1 = new Thread(() => HotelSupplierObj[0].supplierThread());
            Thread t2 = new Thread(() => HotelSupplierObj[1].supplierThread());

            Thread t3 = new Thread(() => HotelSupplierObj[0].getterThread());
            Thread t4 = new Thread(() => HotelSupplierObj[1].getterThread());
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            Console.WriteLine("Operation Complete");
        }
    }
}
