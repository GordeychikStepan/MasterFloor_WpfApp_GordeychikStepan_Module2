using System;
using System.Collections.Generic;

namespace TechGear_WpfApp_Test1.Models;

public partial class PartnerType
{
    public int PartnerTypeId { get; set; }

    public string? PartnerTypeName { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
