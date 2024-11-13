using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class VehicleType
{
    public int VehicleTypeId { get; set; }

    public string? VehicleTypeName { get; set; }

    public string? IconUrl { get; set; }

    public bool? IsIcon { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
