using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class Delegation
    {
        [Key] // Đánh dấu thuộc tính là khóa chính
        public int DelegationId { get; set; }

        [Required(ErrorMessage = "StaffId is required.")]
        public string StaffId { get; set; } = null!;

        [Required(ErrorMessage = "DepartmentId is required.")]
        public string DepartmentId { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Delegation Date")]
        [Required(ErrorMessage = "Delegation Date is required.")]
        public DateTime? DelegationDate { get; set; }

        public bool? Validation { get; set; }

        public virtual Department Department { get; set; } = null!;

        public virtual Staff Staff { get; set; } = null!;
    }
}
