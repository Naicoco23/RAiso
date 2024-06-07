using RAiso.Handler;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controller
{
    public class TransactionHeaderController
    {
        public static Response<List<TransactionHeader>> GetAllTransaction()
        {
            return TransactionHeaderHandler.GetAllTransactionData();
        }

        public static Response<List<TransactionHeader>> GetAllTransactionById(int userId)
        {
            return TransactionHeaderHandler.GetAllTransactionDataByID(userId);
        }

        public static Response<TransactionHeader> CreateTransactionHeader(int Id)
        {
            return TransactionHeaderHandler.CreateTransactionHeader(Id);
        }
    }
}