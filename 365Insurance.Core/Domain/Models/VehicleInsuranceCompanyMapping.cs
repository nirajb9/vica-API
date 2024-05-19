using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class VehicleInsuranceCompanyMapping
{
    public int VehicleInsuranceMappingId { get; set; }

    public int? VehicleinfoId { get; set; }

    public int? InsuranceCompanyId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
