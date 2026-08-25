using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class CollectionRequest
{
    public int RequestId { get; set; }

    public int RId { get; set; }

    public int EId { get; set; }

    public string FoodDescription { get; set; } = null!;

    public decimal Quantity { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime PreserveUntil { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CollectionTime { get; set; }

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();

    public virtual Employee EIdNavigation { get; set; } = null!;

    public virtual Restaurant RIdNavigation { get; set; } = null!;
}
