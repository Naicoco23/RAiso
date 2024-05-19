using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int TransactionID, int UserID)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionID = TransactionID,
                UserID = UserID,
                TransactionDate = DateTime.Now
            };
            return transactionHeader;
        }
    }
}