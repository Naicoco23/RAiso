using RAiso.Factory;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class TransactionHeaderRepository
    {
        static RAisoEntities db = DatabaseSingleton.CreateInstance();

        public static List<TransactionHeader> GetAllTransaction()
        {
            return db.TransactionHeaders.ToList();
        }

        public static TransactionHeader GetLastTransaction()
        {
            //return (from x in db.TransactionHeaders select x).LastOrDefault();
            return db.TransactionHeaders.ToList().LastOrDefault();
        }

        public static TransactionHeader CreateTransactionHeader(int TransactionID, int UserID)
        { 
            TransactionHeader th = TransactionHeaderFactory.Create(TransactionID, UserID);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
            return th;
        }

        public static List<TransactionHeader> GetAllTransactionByUserId(int userId)
        {
            return (from x in db.TransactionHeaders where x.UserID == userId select x).ToList();
        }
    }
}