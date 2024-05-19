using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class CartFactory
    {
        public static Cart Create(int UserID, int StationeryID, int Quantity)
        {
            Cart cart = new Cart()
            {
                UserID = UserID,
                StationeryID = StationeryID,
                Quantity = Quantity
            };
            return cart;
        }
    }
}