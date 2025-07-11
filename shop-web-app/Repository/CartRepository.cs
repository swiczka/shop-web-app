﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;

namespace shop_web_app.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CartItem item)
        {
            _context.CartItems.Add(item);
            return Save();
        }

        public bool Delete(CartItem item)
        {
            _context.CartItems.Remove(item);
            return Save();
        }

        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => cartItemId == ci.Id);
            return cartItem;
        }


        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(CartItem item)
        {
            _context.CartItems.Update(item);
            return Save();
        }
    }
}
