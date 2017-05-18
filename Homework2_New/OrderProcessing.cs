using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework2_New
{
    class OrderProcessing
    {
        public delegate void orderCompletedDelegate(int id1, int id2);
        public static event orderCompletedDelegate orderCompleted;
        static double total_amount = 0.0;
        public static void processingThread(OrderClass order, int price)
        {
            total_amount = price * order.getAmount();
            if (order.getCardNo() < 1000 || order.getCardNo() > 10000)
            {
                total_amount = 0.0;
                Console.WriteLine("Unacceptable card number");
            }
        }

        public static double processOrder(OrderClass order, int price)
        {
            Thread procThread = new Thread(() => processingThread(order, price));
            procThread.Start();
            Thread.Sleep(1000);
            procThread.Join();
            Console.WriteLine("\nOrder Received from Travel Agency " + Convert.ToString(order.getSenderId()) + " for Hotel Supplier " + Convert.ToString(order.getReceiverID()) + " for " + Convert.ToString(order.getAmount()) + " rooms");
            Console.WriteLine("Amount Charged = " + total_amount + "\n");

            orderCompleted(order.getSenderId(),order.getReceiverID());
            return total_amount;
        }
    }
}
