using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class OfflineQuotationRequest
{
    public int OfflineQuotationId { get; set; }

    public decimal? Idv { get; set; }

    public string? Insurancecompanies { get; set; }

    public string? Status { get; set; }

    public string? RcFUrlm { get; set; }

    public string? RcBUrlm { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? UserId { get; set; }

    public bool? Pacover { get; set; }

    public bool? Dacover { get; set; }

    public bool? Passangercover { get; set; }

    public string? VehicleNo { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
