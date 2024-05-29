using RAiso.Models;
using RAiso.Modules;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Services.Description;

namespace RAiso.Handler
{
    public class CartHandler
    {

        public static Response<List<Cart>> GetCartListById(int userId)
        {
            List<Cart> list = CartRepository.GetCartsById(userId);
  
            if(list == null || !list.Any())
            {
                return new Response<List<Cart>>() 
                {
                    IsSuccess = false,
                    Message = "Cart is Empty!",
                    Payload = null
                };
            }

            else
            {
                return new Response<List<Cart>>()
                {
                    IsSuccess = true,
                    Message = "Retrieved Successfully!",
                    Payload = list
                };
            }

        }

        public static Response<Cart> AddToCart(int userId, int statId, int qty)
        {   
            Cart cart = CartRepository.FindCartDetail(userId, statId);
            if(cart == null)
            {
                CartRepository.AddToCart(userId, statId, qty);
                return new Response<Cart>()
                {
                    IsSuccess = true,
                    Message = "Succesfully added new Item to cart!!",
                    Payload = null
                };
            }
            else
            {
                CartRepository.UpdateQuantity(userId, statId, qty);
                return new Response<Cart>()
                {
                    IsSuccess = true,
                    Message = "Succesfully update the quantity!!",
                    Payload = null
                };
            }
        }

        public static Response<Cart> RemoveItem(int userId, int statId)
        {
            Cart toDelete = CartRepository.FindCartDetail(userId,statId);
            if (toDelete == null)
            {
                return new Response<Cart>()
                {
                    IsSuccess = false,
                    Message = "Desired item not found!!!",
                    Payload = null
                };
            }
            else
            {
                CartRepository.RemoveItem(toDelete);
                return new Response<Cart>
                {
                    IsSuccess = true,
                    Message = "Item successfully removed :)",
                    Payload = null
                };
            }

        }

        public static Response<Cart> GetUpdateItem(int userId, int statId) 
        {
            Cart toUpdate = CartRepository.FindCartDetail(userId, statId);
            if (toUpdate == null)
            {

                return new Response<Cart>()
                {
                    IsSuccess = false,
                    Message = "No item to be updated!!!",
                    Payload = null
                };
            }
            else
            {
                return new Response<Cart>
                {
                    IsSuccess = true,
                    Message = "Successfully retrieve item...",
                    Payload = toUpdate
                };
            }
        }

        public static Response<Cart> UpdateItem(int userId, int statId, int qty) 
        {
            CartRepository.UpdateItem(userId, statId, qty);
            return new Response<Cart>
            {
                IsSuccess = true,
                Message = "Item successfully updated :)",
                Payload = null
            };
        }

        public static Response<Cart> CheckOutItem(int userId)
        {
            CartRepository.CheckOutCart(userId);


            return new Response<Cart>
            {
                IsSuccess = true,
                Message = "Successfully checkout!!!",
                Payload = null
            };
        }

        public static Response<List<Cart>> GetAllItemByUserId(int userId)
        {
           List<Cart> temp = CartRepository.GetAllItemByUserId(userId);
            if (!temp.Any() || temp == null)
            {
                return new Response<List<Cart>>
                {
                    IsSuccess = false,
                    Message = "No Items Available",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<Cart>>
                {
                    IsSuccess = true,
                    Message = "Showing Available Items",
                    Payload = temp
                };
            }
        }
    }
}
