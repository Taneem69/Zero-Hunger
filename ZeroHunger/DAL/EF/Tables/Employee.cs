using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Employee
{
    public int EId { get; set; }

    public string Ename { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<CollectionRequest> CollectionRequests { get; set; } = new List<CollectionRequest>();

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();
}
