using Mycloth_website.Interfaces;
using Mycloth_website.Models;
using WebApplication1.NewFolder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mycloth_website.Services
{
    public class ItemService1 : IItemService1
    {
        private readonly ApplicationDbContex _dbContext;

        public ItemService1(ApplicationDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MenCategory> GetMenCategory()
        {

            IEnumerable<MenCategory> data = _dbContext.MenCategory;
            return data;
        }
        public IEnumerable<WomenCategory> GetWomenCategory()
        {

            IEnumerable<WomenCategory> data = _dbContext.WomenCategory;
            return data;
        }

        public IEnumerable<KidsCategory> GetKidsCategory()
        {

            IEnumerable<KidsCategory> data = _dbContext.KidsCategory;
            return data;
        }

        public IEnumerable<Cart> GetCart()
        {

            IEnumerable<Cart> data = _dbContext.Cart;
            return data;
        }
    }
}
