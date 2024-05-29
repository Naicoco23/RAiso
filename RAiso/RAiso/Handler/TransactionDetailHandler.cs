using RAiso.Models;
using RAiso.Modules;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace RAiso.Handler
{
    public class TransactionDetailHandler
    {
        public static Response<List<TransactionDetail>> GetAllTransactionDetail()
        {
            List<TransactionDetail> td = TransactionDetailRepository.GetAllTransactionDetails();
            if(td == null || !td.Any() )
            {
                return new Response<List<TransactionDetail>>()
                {
                    IsSuccess = false,
                    Message = "No Details available",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<TransactionDetail>>()
                {
                    IsSuccess = true,
                    Message = "Showing Details",
                    Payload = td
                };
            }
        }

        public static Response<List<TransactionDetail>> GetAllTransactionDetailById(int id)
        {
            List<TransactionDetail> td = TransactionDetailRepository.GetAllTransactionDetailsById(id);
            if (td == null || !td.Any())
            {
                return new Response<List<TransactionDetail>>()
                {
                    IsSuccess = false,
                    Message = "No Details available",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<TransactionDetail>>()
                {
                    IsSuccess = true,
                    Message = "Showing Details",
                    Payload = td
                };
            }
        }

        public static void SetTransactionQuantity(Response<List<Cart>> response, int transId)
        {
            TransactionDetailRepository.SetTransactionDetail(transId, response);

        }
    }
}