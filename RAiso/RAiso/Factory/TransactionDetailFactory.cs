using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int TransactionID, int StationeryID, int Quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = TransactionID,
                StationeryID = StationeryID,
                Quantity = Quantity
            };
            return transactionDetail;
        }
    }
}