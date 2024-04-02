using Mycloth_website.Lists;

namespace Mycloth_website.Models
{
    public class IndexViewModel
    {
        public PaginatedList<MenCategory> MenItems { get; set; }
        public PaginatedList<WomenCategory> WomenItems { get; set; }
        public PaginatedList<KidsCategory> KidItems { get; set; }
    }
}
