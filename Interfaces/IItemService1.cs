using Mycloth_website.Models;

namespace Mycloth_website.Interfaces
{
    public interface IItemService1
    {
        IEnumerable<MenCategory> GetMenCategory();
        IEnumerable<WomenCategory> GetWomenCategory();
        IEnumerable<KidsCategory> GetKidsCategory();
        IEnumerable<Cart> GetCart();
    }
}
