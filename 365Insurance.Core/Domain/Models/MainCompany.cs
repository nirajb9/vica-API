using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class MainCompany
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? TagLine { get; set; }

    public string? LogoUrl { get; set; }

    public bool? IsVendorActive { get; set; }
}
