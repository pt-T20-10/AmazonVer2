using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class WebSite
    {
        [Key] // Đánh dấu thuộc tính là khóa chính
        public int PageId { get; set; }

        [Required(ErrorMessage = "WebsiteSName is required.")]
        [StringLength(100, ErrorMessage = "WebsiteSName cannot exceed 100 characters.")]
        public string WebsiteSName { get; set; } = null!;

        [Required(ErrorMessage = "Url is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string Url { get; set; } = null!;

        public virtual ICollection<Authorization> Authorizations { get; set; } = new List<Authorization>();
    }
}
