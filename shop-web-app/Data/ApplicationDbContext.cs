using Microsoft.EntityFrameworkCore;

namespace shop_web_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {   
            
        }
    }
}

