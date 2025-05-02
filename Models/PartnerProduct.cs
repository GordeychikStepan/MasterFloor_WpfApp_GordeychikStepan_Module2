using System;
using System.Collections.Generic;

namespace TechGear_WpfApp_Test1.Models;

public partial class PartnerProduct
{
    public int PartnerProductId { get; set; }

    public int? ProductId { get; set; }

    public int? PartnerId { get; set; }

    public int? ProductCount { get; set; }

    public DateOnly? DataSale { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Product? Product { get; set; }
}
