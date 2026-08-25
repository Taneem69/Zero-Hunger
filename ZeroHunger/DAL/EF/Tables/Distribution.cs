using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Distribution
{
    public int DId { get; set; }

    public int RequestId { get; set; }

    public int EId { get; set; }

    public DateTime DistributionDate { get; set; }

    public decimal QuantityDistributed { get; set; }

    public string Location { get; set; } = null!;

    public virtual Employee EIdNavigation { get; set; } = null!;

    public virtual CollectionRequest Request { get; set; } = null!;
}
