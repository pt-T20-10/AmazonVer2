using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string CustomerId { get; set; } = null!;

    public DateTime BuyingDate { get; set; }

    public DateTime? EstimatedDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? Name { get; set; }

    public string Address { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string DeliveryMethod { get; set; } = null!;

    public double DeliveryPrice { get; set; }

    public int StatusId { get; set; }

    public string? StaffId { get; set; }

    public string? Note { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Staff? Staff { get; set; }

    public virtual Status Status { get; set; } = null!;
}
