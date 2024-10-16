using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class VOrderDetail
{
    public int OrderDetailsId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public string ProductName { get; set; } = null!;
}
