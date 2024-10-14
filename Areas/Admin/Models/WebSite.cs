using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class WebSite
{
    public int PageId { get; set; }

    public string WebsiteSName { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<Authorization> Authorizations { get; set; } = new List<Authorization>();
}
