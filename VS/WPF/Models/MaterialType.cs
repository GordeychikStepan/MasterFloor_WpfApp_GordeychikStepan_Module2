using System;
using System.Collections.Generic;

namespace TechGear_WpfApp_Test1.Models;

public partial class MaterialType
{
    public int ProductMaterialId { get; set; }

    public string? ProductMaterialName { get; set; }

    public decimal? PercentDamage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
