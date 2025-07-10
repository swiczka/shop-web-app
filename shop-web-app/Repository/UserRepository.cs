using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;

namespace shop_web_app.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUser> GetUserWithAddress(string userId)
        {
            var user = await _userManager.Users
                .Include(a => a.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async Task<List<AppUser>> GetUsersByEmailAndId(string? email, string? id, string? role)
        {
            var query = _userManager.Users.AsQueryable();

            if (email != null)
            {
                query = query.Where(a => a.Email.Contains(email));
            }
            if(id != null)
            {
                query = query.Where(a => a.Id == id);
            }
            if (role != null)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role);
                var userIds = usersInRole.Select(a => a.Id).ToList();
                query = query.Where(u => userIds.Contains(u.Id));
            }

            var users = await query.ToListAsync();

            return users;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            var users = await _userManager.Users
                .ToListAsync();
            return users;
        }

        public async Task<List<CartItem>> GetCartItems(string userId)
        {
            var user = await _userManager.Users
                .Include(u => u.CartItems)
                    .ThenInclude(v => v.Variant)
                        .ThenInclude(h => h.Photos)
                .Include(u => u.CartItems)
                    .ThenInclude(v => v.Variant)
                    .ThenInclude(p => p.Product)
                .Include(u => u.CartItems)
                    .ThenInclude(v => v.Variant)
                    .ThenInclude(p => p.InternationalSizeQuantity)
                .Include(u => u.CartItems)
                    .ThenInclude(v => v.Variant)
                    .ThenInclude(p => p.ShoeSizeQuantity)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                return user.CartItems.ToList();
            }
            return new List<CartItem>();
        }

        //public async Task<CartItem> GetCartItemById(string cartId)
    }
}
