using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class ProductType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? TypeAliasName { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
