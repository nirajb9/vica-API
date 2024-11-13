using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class VehicleCubicCapicity
{
    public int CubicCapicityId { get; set; }

    public int? VehicleTypeId { get; set; }

    public string? CubicCapicityName { get; set; }

    public int? CcGcwRangeMin { get; set; }

    public int? CcGcwRangeMax { get; set; }

    public string? Unit { get; set; }

    public bool? State { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
