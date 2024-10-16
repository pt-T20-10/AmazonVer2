using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class Delegation
{
    public int DelegationId { get; set; }

    public string StaffId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public DateTime? DelegationDate { get; set; }

    public bool? Validation { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
