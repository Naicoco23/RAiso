using RAiso.Factory;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class TransactionDetailRepository
    {
        static RAisoEntities db = DatabaseSingleton.CreateInstance();

        public static List<TransactionDetail> GetAllTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }

        public static List<TransactionDetail> GetAllTransactionDetailsById(int id)
        {
            return (from x in db.TransactionDetails where x.TransactionID == id select x).ToList();
        }

        public static void SetTransactionDetail(int transId, Response<List<Cart>> qty)
        {
            foreach (Cart c in qty.Payload)
            {
                TransactionDetail td = new TransactionDetail()
                {
                    TransactionID = transId,
                    StationeryID = c.StationeryID,
                    Quantity = c.Quantity
                };
                db.TransactionDetails.Add(td);
            }
            db.SaveChanges();
        }
    }        
}