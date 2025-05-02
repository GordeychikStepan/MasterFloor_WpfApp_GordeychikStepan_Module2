using System;
using System.Collections.Generic;

namespace TechGear_WpfApp_Test1.Models;

public partial class Partner
{
    public int PartnerId { get; set; }

    public int? PartnerTypeId { get; set; }

    public string? PartnerName { get; set; }

    public string? PartnerCeo { get; set; }

    public string? PartnerEmail { get; set; }

    public string? PartnerPhone { get; set; }

    public string? PartnerAddress { get; set; }

    public string? Inn { get; set; }

    public int? Rating { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual PartnerType? PartnerType { get; set; }
}
