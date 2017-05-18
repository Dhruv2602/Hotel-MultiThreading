using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework2_New
{
    public class MultiCellBuffer
    {
        private int writectr = -1;
        private int readctr = -1;

        private readonly String[] arr = new String[3];
        private readonly Semaphore write = new Semaphore(3, 3);
        private readonly Semaphore read = new Semaphore(0, 3);

        public void setOneCell(string str)
        {
            write.WaitOne();
            lock (this)
            {
                writectr++;
                writectr = writectr % 3;
                arr[writectr] = str;
            }
            read.Release();
        } 


        public string getOneCell()
        {
            string str = "";

            read.WaitOne();
            lock (this)
            {
                readctr++;
                readctr = readctr % 3;
                write.Release();
                str = arr[readctr];
                arr[readctr] = null;
                return str;
            }
        }
    }
}
