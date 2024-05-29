using RAiso.Models;
using RAiso.Modules;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class TransactionHeaderHandler
    {
        public static Response<List<TransactionHeader>> GetAllTransactionData()
        {
            List<TransactionHeader> th = TransactionHeaderRepository.GetAllTransaction();
            if (th == null || !th.Any())
            {
                return new Response<List<TransactionHeader>>()
                {
                    IsSuccess = false,
                    Message = "No Transaction Available",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<TransactionHeader>>()
                {
                    IsSuccess = true,
                    Message = "Showing All Available Transaction",
                    Payload = th
                };
            }

        }

        public static int GetTransactionId()
        {
            TransactionHeader temp = TransactionHeaderRepository.GetLastTransaction();
            int newId;
            if (temp == null)
            {
                return newId = 1;
            }
            else
            {
                return newId = temp.TransactionID + 1;
            }
        }

        public static Response<TransactionHeader> CreateTransactionHeader(int id)
        {
            int newId = GetTransactionId();
            TransactionHeader th = TransactionHeaderRepository.CreateTransactionHeader(newId, id);
            return new Response<TransactionHeader>()
            {
                IsSuccess = true,
                Message = "Succesfuly Created New Transaction Header",
                Payload = th
            };
        }

        //public static Response<TransactionDetail> CreateTransactionDetail(int id)
        //{

        //}
    }
}