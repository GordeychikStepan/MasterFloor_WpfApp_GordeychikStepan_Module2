using System;
using System.Collections.Generic;

namespace TechGear_WpfApp_Test1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? ProductTypeId { get; set; }

    public int? ProductMaterialId { get; set; }

    public string? ProductName { get; set; }

    public string? Articul { get; set; }

    public decimal? MinimumPrice { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual MaterialType? ProductMaterial { get; set; }

    public virtual ProductType? ProductType { get; set; }
}
