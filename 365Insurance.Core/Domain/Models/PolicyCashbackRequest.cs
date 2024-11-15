using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class PolicyCashbackRequest
{
    public int PolicyCashbackRequestId { get; set; }

    public int? UserId { get; set; }

    public string? VehicleNo { get; set; }

    public string? PolicyUrlM { get; set; }

    public int? AgentCompanyId { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
