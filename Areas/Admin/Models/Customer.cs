using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? Password { get; set; }

    public string Name { get; set; } = null!;

    public bool Sex { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumbers { get; set; }

    public string Email { get; set; } = null!;

    public string? Image { get; set; }

    public bool Validation { get; set; }

    public int Role { get; set; }

    public string? RandomKey { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
