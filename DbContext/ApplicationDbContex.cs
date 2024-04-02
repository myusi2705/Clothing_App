using Mycloth_website.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.NewFolder
{
    public class ApplicationDbContex:DbContext
    {
        public ApplicationDbContex()
        {
            
        }
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options) 
        { 
             
        }
        public DbSet<MenCategory> MenCategory { get; set; }
        public DbSet<WomenCategory> WomenCategory { get; set; }
        public DbSet<KidsCategory> KidsCategory { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
