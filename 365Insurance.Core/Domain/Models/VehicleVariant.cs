using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class VehicleVariant
{
    public int VehicleVariantId { get; set; }

    public int ModelId { get; set; }

    public int? CompanyId { get; set; }

    public string? VariantName { get; set; }

    public int? CubicCapicityId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
