using System.ComponentModel.DataAnnotations;

namespace Mycloth_website.Models
{
    public class KidsCategory
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product image is required")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Product description is required")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Discounted product price is required")]
        public decimal DicountProductPrice { get; set; }
    }
}
