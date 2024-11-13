using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class VehicleCompany
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyLogo { get; set; }

    public bool? State { get; set; }

    public bool? IsDeleted { get; set; }

    public int? VehicleType { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
