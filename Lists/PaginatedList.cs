namespace Mycloth_website.Lists
{
    public class PaginatedList<MenCategory>
    {
        public List<MenCategory> Items { get; private set; }
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<MenCategory> items, int pageNumber, int totalPages)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = totalPages;
        }
    }

    public class PaginatedList1<WomenCategory>
    {
        public List<WomenCategory> Items { get; private set; }
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList1(List<WomenCategory> items, int pageNumber, int totalPages)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = totalPages;
        }
    }

    public class PaginatedList2<KidsCategory>
    {
        public List<KidsCategory> Items { get; private set; }
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList2(List<KidsCategory> items, int pageNumber, int totalPages)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = totalPages;
        }
    }

    public class PaginatedList3<Cart>
    {
        public List<Cart> Items { get; private set; }
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList3(List<Cart> items, int pageNumber, int totalPages)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = totalPages;
        }
    }
}
