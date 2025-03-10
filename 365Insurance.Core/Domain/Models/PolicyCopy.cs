﻿using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class PolicyCopy
{
    public int PolicyCopyId { get; set; }

    public int? UserId { get; set; }

    public string? VehicleNo { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? TpRequestId { get; set; }

    public string? PolicyCopyUrl { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
