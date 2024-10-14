using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class Staff
{
    public string StaffId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<Delegation> Delegations { get; set; } = new List<Delegation>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
