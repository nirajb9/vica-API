using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class VehicleFueltype
{
    public int FueltypeId { get; set; }

    public string? FueltypeName { get; set; }

    public bool? State { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
