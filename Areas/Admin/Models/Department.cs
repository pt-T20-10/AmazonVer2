using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class Department
    {
        [Required(ErrorMessage = "DepartmentId is required.")]
        public string DepartmentId { get; set; } = null!;

        [Required(ErrorMessage = "DepartmentName is required.")]
        [StringLength(100, ErrorMessage = "DepartmentName cannot exceed 100 characters.")]
        public string DepartmentName { get; set; } = null!;

        [StringLength(500, ErrorMessage = "DepartmentInfor cannot exceed 500 characters.")]
        public string? DepartmentInfor { get; set; }

        public virtual ICollection<Authorization> Authorizations { get; set; } = new List<Authorization>();

        public virtual ICollection<Delegation> Delegations { get; set; } = new List<Delegation>();
    }
}
