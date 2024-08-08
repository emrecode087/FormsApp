﻿using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Required]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

		[Required(ErrorMessage = "Please enter a name")]
		[Display(Name = "Name")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a price")]
		[Display(Name = "Price")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Please enter an image")]
		[Display(Name = "Image")]
		public string Image { get; set; } = string.Empty;

		[Display(Name = "Is Active")]
		public bool isActive { get; set; }

		[Display(Name = "Category")]
		[Required(ErrorMessage = "Please select a category")]
		public int? CategoryId { get; set; }
    }
}
