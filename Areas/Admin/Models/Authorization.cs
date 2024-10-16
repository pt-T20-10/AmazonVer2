using System;
using System.Collections.Generic;

namespace AmazonWebsite.Areas.Admin.Models;

public partial class Authorization
{
    public int AuthorizationId { get; set; }

    public string? DepartmentId { get; set; }

    public int? PageId { get; set; }

    public bool Add { get; set; }

    public bool Edit { get; set; }

    public bool Delete { get; set; }

    public bool Detial { get; set; }

    public virtual Department? Department { get; set; }

    public virtual WebSite? Page { get; set; }
}
