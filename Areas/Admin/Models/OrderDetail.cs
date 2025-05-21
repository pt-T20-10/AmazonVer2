using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class OrderDetail
    {
        [Key] // Đánh dấu thuộc tính là khóa chính
        public int OrderDetailsId { get; set; }

        [Required(ErrorMessage = "OrderId is required.")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public double Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
