using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int? ProductId { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? ChoosingDate { get; set; }

    public string? Description { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
