using RAiso.Handler;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controller
{
    public class TransactionDetailController
    {
        public static Response<List<TransactionDetail>> GetAllTransactionDetail()
        {
            return TransactionDetailHandler.GetAllTransactionDetail();
        }

        public static Response<List<TransactionDetail>> GetAllTransactionDetailById(int id)
        {
            return TransactionDetailHandler.GetAllTransactionDetailById(id);
        }

        public static void SetTransactionDetailQty(Response<List<Cart>> response, int transId)
        {
            TransactionDetailHandler.SetTransactionQuantity(response, transId);
        }
    }
}