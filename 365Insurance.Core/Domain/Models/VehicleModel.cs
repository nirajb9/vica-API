using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class VehicleModel
{
    public int ModelId { get; set; }

    public int? CompanyId { get; set; }

    public string? ModelName { get; set; }

    public int? CubicCapicityId { get; set; }

    public bool? State { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
