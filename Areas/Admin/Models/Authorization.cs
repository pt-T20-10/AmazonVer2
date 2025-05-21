using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AmazonWebsite.Areas.Admin.Models;



public partial class Authorization
{
    [Key]
    public int AuthorizationId { get; set; }

    [Required(ErrorMessage = "DepartmentId is required.")]
    public string? DepartmentId { get; set; }

    [Required(ErrorMessage = "PageId is required.")]
    public int? PageId { get; set; }

    [Required(ErrorMessage = "Add permission is required.")]
    public bool Add { get; set; }

    [Required(ErrorMessage = "Edit permission is required.")]
    public bool Edit { get; set; }

    [Required(ErrorMessage = "Delete permission is required.")]
    public bool Delete { get; set; }

    [Required(ErrorMessage = "Detail permission is required.")]
    public bool Detail { get; set; }

    public virtual Department? Department { get; set; }

    public virtual WebSite? Page { get; set; }
}

