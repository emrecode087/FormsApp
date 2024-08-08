using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Required]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Price")]
		public decimal Price { get; set; }

		[Display(Name = "Image")]
		public string Image { get; set; } = string.Empty;

		[Display(Name = "Is Active")]
		public bool isActive { get; set; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }
    }
}
