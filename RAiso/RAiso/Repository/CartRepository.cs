using RAiso.Factory;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class CartRepository
    {
       
        private static RAisoEntities db = DatabaseSingleton.CreateInstance();

        public static List<Cart> GetCartsById(int userId) {
            return db.Carts.Where(cart => cart.UserID == userId).ToList();
        }

        public static void AddToCart(int userId, int statId, int qty)
        {
            Cart newCart = CartFactory.Create(userId, statId, qty);
            db.Carts.Add(newCart);
            db.SaveChanges();
        }

        public static Cart FindCartDetail(int userId, int statId)
        {
            return db.Carts.Where(cart => (cart.UserID == userId) && (cart.StationeryID == statId)).FirstOrDefault();
        }

        public static void UpdateQuantity(int userId, int statId, int quantity)
        {
            Cart cart = FindCartDetail(userId, statId);
            cart.Quantity += quantity;
            db.SaveChanges();
        }

        public static void RemoveItem(Cart toDelete)
        {
            db.Carts.Remove(toDelete); 
            db.SaveChanges();
        }

        public static void UpdateItem(int userId, int statId, int quantity)
        {
            Cart cart = FindCartDetail(userId, statId);
            cart.Quantity = quantity;
            db.SaveChanges();
        }
       
        public static void CheckOutCart(int userId)
        {
            var carts = db.Carts.Where(cart => cart.UserID == userId).ToList();
            foreach (var cart in carts)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static List<Cart> GetAllItemByUserId(int userId)
        {
            return (from x in db.Carts where x.UserID == userId select x).ToList();
        }
    }
}