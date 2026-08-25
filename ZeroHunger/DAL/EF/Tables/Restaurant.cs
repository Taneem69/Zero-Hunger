using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Restaurant
{
    public int RId { get; set; }

    public string Rname { get; set; } = null!;

    public string PersonContacted { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<CollectionRequest> CollectionRequests { get; set; } = new List<CollectionRequest>();
}
