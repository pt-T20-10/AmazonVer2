using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class Status
    {
        [Key] // Đánh dấu thuộc tính là khóa chính
        public int StatusId { get; set; }

        [Required(ErrorMessage = "StatusName is required.")]
        [StringLength(100, ErrorMessage = "StatusName cannot exceed 100 characters.")]
        public string StatusName { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
