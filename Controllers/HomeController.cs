using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mycloth_website.Areas.Identity.Data;
using Mycloth_website.Models;
using Mycloth_website.Services;
using System.Diagnostics;
using WebApplication1.NewFolder;
using Mycloth_website.Lists;

namespace Mycloth_website.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContex _db;
        private readonly ItemService1 _itemService;
        private const int PageSize = 12;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContex db, ItemService1 itemService)
        {
            _logger = logger;
            _userManager = userManager;
            _db = db;
            _itemService = itemService;
        }

        public IActionResult Index(int page = 1)
        {
            var items = _itemService.GetMenCategory();
            var totalItems = items.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);
            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items1 = _itemService.GetWomenCategory();
            var totalItems1 = items1.Count();
            var totalPages1 = (int)Math.Ceiling((double)totalItems1 / PageSize);
            var paginatedItems1 = items1.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items2 = _itemService.GetKidsCategory();
            var totalItems2 = items2.Count();
            var totalPages2 = (int)Math.Ceiling((double)totalItems2 / PageSize);
            var paginatedItems2 = items2.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var menPaginatedList = new PaginatedList<MenCategory>(paginatedItems, page, totalPages);
            var womenPaginatedList = new PaginatedList<WomenCategory>(paginatedItems1, page, totalPages1);
            var kidPaginatedList = new PaginatedList<KidsCategory>(paginatedItems2, page, totalPages2);

            var viewModel = new IndexViewModel
            {
                MenItems = menPaginatedList,
                WomenItems = womenPaginatedList,
                KidItems = kidPaginatedList
            };
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            return View(viewModel);
        }

        public IActionResult Mans(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetMenCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<MenCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult MenSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.MenCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Mans");
        }

        public IActionResult Womens(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            var items = _itemService.GetWomenCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList1<WomenCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult WomenSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.WomenCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Womens");
        }


        public IActionResult MenDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found vipul");
            }
            var studentregister = _db.MenCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }


        public IActionResult WomenDetails(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            if (id == null || id == 0)
            {
                return NotFound("Data Not Found vipul");
            }
            var studentregister = _db.WomenCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            return View(studentregister);
        }


        public IActionResult Kids(int page = 1)
        {

            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetKidsCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList2<KidsCategory>(paginatedItems, page, totalPages));
        }

        public IActionResult KidDetails(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.KidsCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            return View(studentregister);
        }
        public IActionResult KidsSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.KidsCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Kids");
        }

        public IActionResult Cart(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            var items = _itemService.GetCart();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList3<Cart>(paginatedItems, page, totalPages));
        }



        public IActionResult DeleteFromCart(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var itemToDelete = _db.Cart.Find(id);
            if (itemToDelete == null)
            {
                return NotFound("ggwr"); // Return a 404 Not Found if the item is not found
            }

            _db.Cart.Remove(itemToDelete); // Remove the item from the cart
            _db.SaveChanges(); // Save changes to the database
            TempData["Message"] = "Item removed successfully";

            return RedirectToAction("Cart"); // Redirect back to the cart page
        }


        public IActionResult CartDetails(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.Cart.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            return View(studentregister);
        }


        public IActionResult aboutUs()
        {
            var cart = _itemService.GetCart();
            var totalcart = cart.Count();
            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        public IActionResult ContactUs()
        {
            var cart = _itemService.GetCart();
            var totalcart = cart.Count();
            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        [HttpGet]
        public IActionResult AddMen()
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult AddMen(MenCategory register)
        {
            var userData = new MenCategory()
            {
                ProductName = register.ProductName,
                ProductImage = register.ProductImage,
                ProductDescription = register.ProductDescription,
                ProductPrice = register.ProductPrice,
                DicountProductPrice = register.DicountProductPrice
            };
            _db.MenCategory.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddWomen()
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult AddWomen(WomenCategory register)
        {
            var userData = new WomenCategory()
            {
                ProductName = register.ProductName,
                ProductImage = register.ProductImage,
                ProductDescription = register.ProductDescription,
                ProductPrice = register.ProductPrice,
                DicountProductPrice = register.DicountProductPrice
            };
            _db.WomenCategory.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("AddWomen");
        }

        [HttpGet]
        public IActionResult AddKid()
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult AddKid(KidsCategory register)
        {
            var userData = new KidsCategory()
            {
                ProductName = register.ProductName,
                ProductImage = register.ProductImage,
                ProductDescription = register.ProductDescription,
                ProductPrice = register.ProductPrice,
                DicountProductPrice = register.DicountProductPrice
            };
            _db.KidsCategory.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("AddKid");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}