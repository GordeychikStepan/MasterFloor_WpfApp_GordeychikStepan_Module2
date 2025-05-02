using System;
using System.Collections.Generic;

namespace TechGear_WpfApp_Test1.Models;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string? ProductTypeName { get; set; }

    public decimal? Coefficient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
