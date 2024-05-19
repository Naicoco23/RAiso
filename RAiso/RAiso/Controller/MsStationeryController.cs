using RAiso.Handler;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controller
{
    public class MsStationeryController
    {
        public static Response<List<MsStationery>> GetStationery(String search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return MsStationeryHandler.GetAllStationery();
            }
            else
            {
                return MsStationeryHandler.SearchStationery(search);
            }
        }

        public static Response<MsStationery> GetStationeryById(int id)
        {
            return MsStationeryHandler.GetStationeryById(id);
        }

        public static Response<MsStationery> AddStationery(String name, String price)
        {
            String Error = "";
            int prices=-1;

            if (decimal.TryParse(price, out decimal priceDecimal))
            {
                prices = (int)Math.Round(priceDecimal);
            }
            else
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = false,
                    Message = "Price must be a number!",
                    Payload = null
                };
            }
            if (string.IsNullOrEmpty(name))
            {
                Error = "Stationery name must be filled!";
            }else if (string.IsNullOrEmpty(price))
            {
                Error = "Price must be be filled!";
            }else if(name.Length<=3 || name.Length>=50)
            {
                Error = "Stationery name between 3 and 50!";
            }else if (prices < 2000)
            {
                Error = "Price must be greater or equal to 2000!";
            }

            if (Error.Equals(""))
            {
                return MsStationeryHandler.AddStationery(name, prices);
            }
            else
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = false,
                    Message = Error,
                    Payload = null
                };
            }
        }

        public static void DeleteStationery(int id)
        {
            MsStationeryHandler.DeleteStationery(id);
        }

        public static Response<MsStationery> UpdateStationery(int id, string name, string price)
        {
            String Error = "";
            int prices = -1;

            if (decimal.TryParse(price, out decimal priceDecimal))
            {
                prices = (int)Math.Round(priceDecimal);
            }
            else
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = false,
                    Message = "Price must be a number!",
                    Payload = null
                };
            }
            if (string.IsNullOrEmpty(name))
            {
                Error = "Stationery name must be filled!";
            }
            else if (string.IsNullOrEmpty(price))
            {
                Error = "Price must be be filled!";
            }
            else if (name.Length <= 3 || name.Length >= 50)
            {
                Error = "Stationery name between 3 and 50!";
            }
            else if (prices < 2000)
            {
                Error = "Price must be greater or equal to 2000!";
            }

            if (Error.Equals(""))
            {
                return MsStationeryHandler.UpdateStationery(id, name, prices);
            }
            else
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = false,
                    Message = Error,
                    Payload = null
                };
            }
        }
    }
}