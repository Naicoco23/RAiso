using RAiso.Handler;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace RAiso.Controller
{
    public class CartController
    {

        public static Response<List<Cart>> GetCartList(int userId)
        {
            return CartHandler.GetCartListById(userId);
        }

        public static Response<Cart> AddToCart(int userId, int statId, int qty)
        {

            if(qty < 1)
            {
                return new Response<Cart>() 
                {
                    IsSuccess = false,
                    Message = "Quantity cannot be 0!!!",
                    Payload = null
                };
            }
            else
            {
                return CartHandler.AddToCart(userId, statId, qty);
            }
        }

        public static Response<Cart> RemoveItem(int userId, int statId) 
        {
           return CartHandler.RemoveItem(userId, statId);        
        }

        public static Response<Cart> GetUpdateItem(int userId, int statId)
        {
            return CartHandler.GetUpdateItem(userId, statId);
        }

        public static Response<Cart> UpdateItem(int userId, int statId, int qty)
        {
 
            if (qty < 1)
            {
                return new Response<Cart>()
                {
                    IsSuccess = false,
                    Message = "Quantity cannot be 0!!!",
                    Payload = null
                };
            }
            else
            {
                return CartHandler.UpdateItem(userId, statId, qty);
            }
        }
        
        public static Response<Cart> CheckOutItem(int userId)
        {
            return CartHandler.CheckOutItem(userId);
        }

        public static Response<List<Cart>> GetAllItemByUserId(int userId)
        {
            return CartHandler.GetAllItemByUserId(userId);
        }
    }
}