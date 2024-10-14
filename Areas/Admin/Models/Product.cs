using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? AliasName { get; set; }

    public int TypeId { get; set; }

    public string? Unit { get; set; }

    public double? Price { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductType Type { get; set; } = null!;
}
