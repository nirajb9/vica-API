using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class VehicleInfo
{
    public int VehicleinfoId { get; set; }

    public string? StateCode { get; set; }

    public int? RtoCode { get; set; }

    public int? ModelId { get; set; }

    public int? FueltypeId { get; set; }

    public int? ManufacturingYear { get; set; }

    public int? CompanyId { get; set; }

    public bool? State { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
