using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class VehicleInsuranceCompany
{
    public int InsuranceCompanyId { get; set; }

    public string? InsuranceCompanyName { get; set; }

    public bool? State { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
