using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_New
{
    class OrderClass
    {
        private int senderId;
        private int cardNo;
        private int receiverID;
        private int amount;

        public OrderClass(int senderId, int cardNo, int receiverID, int amount)
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.amount = amount;
        }

        public void setSenderId(int senderId)
        {
            this.senderId = senderId;
        }

        public int getSenderId()
        {
            return senderId;
        }

        public void setCardNo(int cardNo)
        {
            this.cardNo = cardNo;
        }

        public int getCardNo()
        {
            return cardNo;
        }

        public void setReceiverID(int receiverID)
        {
            this.receiverID = receiverID;
        }

        public int getReceiverID()
        {
            return receiverID;
        }

        public void setAmount(int amount)
        {
            this.amount = amount;
        }

        public int getAmount()
        {
            return amount;
        }
    }
}
